using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections; // Coroutine için

public class PasswordDoor : MonoBehaviour
{
    public GameObject passwordPanel;               // Şifre paneli UI
    public TMP_InputField passwordInput;           // Input field
    public string correctPassword = "1234";        // Doğru şifre
    public GameObject door;                        // Kapı objesi
    public AudioSource doorAudio;                  // Kapı sesi

    private bool isPlayerNear = false;             // Oyuncu triggerda mı
    private bool inputActive = false;              // Input aktif mi
    private bool doorOpened = false;               // Kapı açıldı mı

    void Start()
    {
        passwordPanel.SetActive(false); // Oyun başladığında panel gizli
    }

    void Update()
    {
        // player trigger içindeyse ve Entera bastıysa input aktifleşir
        if (isPlayerNear && !inputActive && !doorOpened)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                passwordInput.Select();
                passwordInput.ActivateInputField();
                inputActive = true;
            }
        }

        // Input aktifse ve Entera basıldıysa şifre kontrol edilir
        if (inputActive && Input.GetKeyDown(KeyCode.Return))
        {
            CheckPassword();
        }
    }

    void CheckPassword()
    {
        if (passwordInput.text.Trim().ToLower() == correctPassword.ToLower())
        {
            Debug.Log("Şifre doğru.");
            OpenDoor();
            ClosePanel();
        }
        else
        {
            Debug.Log("Şifre yanlış.");
            passwordInput.text = "";
            passwordInput.ActivateInputField();
        }
    }

    void OpenDoor()
    {
        if (doorAudio != null && doorAudio.clip != null)
        {
            doorAudio.Play(); // kapı sesi
        }

        if (door != null)
        {
            // Ses bitince kapıyı yok et
            float delay = (doorAudio != null && doorAudio.clip != null) ? doorAudio.clip.length : 0.5f;
            StartCoroutine(CloseDoorAfterDelay(delay));
        }

        doorOpened = true;
    }

    IEnumerator CloseDoorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        door.SetActive(false); // Kapı görünmez olur 
    }

    void ClosePanel()
    {
        passwordPanel.SetActive(false);
        inputActive = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !doorOpened)
        {
            passwordPanel.SetActive(true);
            isPlayerNear = true;
            Debug.Log("Oyuncu triggera girdi ");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !doorOpened)
        {
            passwordPanel.SetActive(false);
            passwordInput.text = "";
            passwordInput.DeactivateInputField();
            isPlayerNear = false;
            inputActive = false;
            Debug.Log("Oyuncu triggerdan çıktı ");
        }
    }
}
