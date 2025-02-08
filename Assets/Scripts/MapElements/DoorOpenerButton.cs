using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpenerButton : MonoBehaviour, IInteractable
{
    [SerializeField] DoorOpener doorOpener;

   
    public void Interact()
    {
        doorOpener.OpenDoor();
    }
}
