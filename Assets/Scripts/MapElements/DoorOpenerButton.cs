using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpenerButton : MonoBehaviour, IInteractable
{
    [SerializeField] DoorOpener doorOpener;
    bool playerHere, grandmaHere;
    EventManager eventManager;
    public InteractableButton button;
    private void Start()
    {
        eventManager = FindAnyObjectByType<EventManager>();
    }
    public void Interact()
    {
        if (playerHere && grandmaHere)
        {
            doorOpener.OpenDoor();
        } else
        {
            eventManager.StartDialogue("ButtonWithoutGrandma");
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            button.ActivateButton();
            playerHere = true;
        }

        if (collision.gameObject.CompareTag("Grandma"))
        {
            button.ActivateButton();
            grandmaHere = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHere = false;
        }

        if (collision.gameObject.CompareTag("Grandma"))
        {
            grandmaHere = false;
        }
    }
}
