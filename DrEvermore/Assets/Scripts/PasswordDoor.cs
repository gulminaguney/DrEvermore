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

    private bool isPlayerNear = false;             // Oyuncu trigger'da mı
    private bool inputActive = false;              // Input aktif mi
    private bool doorOpened = false;               // Kapı açıldı mı

    void Start()
    {
        passwordPanel.SetActive(false); // Oyun başında panel gizli başlar
    }

    void Update()
    {
        // Oyuncu trigger içindeyse ve Enter'a bastıysa input aktifleşir
        if (isPlayerNear && !inputActive && !doorOpened)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                passwordInput.Select();
                passwordInput.ActivateInputField();
                inputActive = true;
            }
        }

        // Input aktifse ve Enter'a basıldıysa şifre kontrol edilir
        if (inputActive && Input.GetKeyDown(KeyCode.Return))
        {
            CheckPassword();
        }
    }

    void CheckPassword()
    {
        if (passwordInput.text.Trim().ToLower() == correctPassword.ToLower())
        {
            Debug.Log("✅ Şifre doğru! Kapı açılıyor...");
            OpenDoor();
            ClosePanel();
        }
        else
        {
            Debug.Log("❌ Şifre yanlış.");
            passwordInput.text = "";
            passwordInput.ActivateInputField();
        }
    }

    void OpenDoor()
    {
        if (doorAudio != null && doorAudio.clip != null)
        {
            doorAudio.Play(); // 🔊 Ses çal
        }

        if (door != null)
        {
            // Ses süresinden sonra kapıyı yok et
            float delay = (doorAudio != null && doorAudio.clip != null) ? doorAudio.clip.length : 0.5f;
            StartCoroutine(CloseDoorAfterDelay(delay));
        }

        doorOpened = true;
    }

    IEnumerator CloseDoorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        door.SetActive(false); // 🔓 Kapı görünmez olur (sahneden yok edilir)
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
            Debug.Log("🟢 Oyuncu trigger'a girdi → panel açıldı.");
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
            Debug.Log("🔴 Oyuncu trigger'dan çıktı → panel kapandı.");
        }
    }
}
