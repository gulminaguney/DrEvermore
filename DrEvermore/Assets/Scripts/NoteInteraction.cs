using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInteraction : MonoBehaviour
{
    public GameObject noteUIPanel;
    private bool playerInRange = false;
    private bool isNoteOpen = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            isNoteOpen = !isNoteOpen;
            noteUIPanel.SetActive(isNoteOpen);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            isNoteOpen = false;
            noteUIPanel.SetActive(false);
        }
    }
}
