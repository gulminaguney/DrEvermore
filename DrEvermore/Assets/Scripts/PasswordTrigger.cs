using UnityEngine;

public class PasswordTrigger : MonoBehaviour
{
    public GameObject passwordPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger'a girildi!");
            passwordPanel.SetActive(true);
        }
    }
}
