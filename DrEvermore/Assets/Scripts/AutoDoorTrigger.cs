using UnityEngine;

public class AutoDoorTrigger : MonoBehaviour
{
    public GameObject door; // Açılıp kapanacak kapı
    public AudioSource doorAudio; // Opsiyonel: kapı sesi

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger'a girildi → Kapı açıldı.");
            if (door != null)
                door.SetActive(false); // Kapıyı aç 
            
            if (doorAudio != null)
                doorAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger'dan çıkıldı → Kapı kapandı.");
            if (door != null)
                door.SetActive(true); // Kapıyı kapat 
        }
    }
}
