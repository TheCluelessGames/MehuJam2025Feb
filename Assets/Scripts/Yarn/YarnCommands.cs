using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnCommands : MonoBehaviour
{
    EventManager eventManager;
    private DialogueRunner dialogueRunner;

    // Start is called before the first frame update
    void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();

        dialogueRunner.AddCommandHandler("activate_grandma", ActivateGrandma);
        dialogueRunner.AddCommandHandler("merchant_idle", MerchantIdle);
    }

    public void ActivateGrandma()
    {
        eventManager.GrandmaStoppingTalking();
    }

    public void MerchantIdle()
    {
        eventManager.MerchantIdle();    
    }

    
}
