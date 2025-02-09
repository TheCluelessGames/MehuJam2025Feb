using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    private bool gunHasBeenGiven;

    EventManager eventManager;

    private void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grandma"))
        {
            if(!gunHasBeenGiven) 
            { 
                gunHasBeenGiven = true;
                eventManager.StartDialogue("MerchantGiveGun");
                eventManager.GrandmaTalking();
            }
            else
            {
                eventManager.StartDialogue("MerchantDefault");
            }
        }
    }
}
