using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    private bool gunHasBeenGiven;

    [SerializeField] private Animator animator;

    EventManager eventManager;

    private void OnEnable()
    {
        eventManager = FindObjectOfType<EventManager>();

        eventManager.onMerchantIdle += MerchantIdling;
    }

    private void OnDisable()
    {
        eventManager.onMerchantIdle -= MerchantIdling;
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
                animator.SetInteger("AnimState", 1);
            }
            else
            {
                eventManager.StartDialogue("MerchantDefault");
                animator.SetInteger("AnimState", 1);
            }
        }
    }

    private void MerchantIdling()
    {
        animator.SetInteger("AnimState", 0);
    }
}
