using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public event Action onShowGameOver;
    public event Action onShowVictory;
    public event Action<string> onStartDialogue;
    public event Action onStopCurrentDialogue;
    public event Action onGrandmaTalking;
    public event Action onGrandmaStoppingTalking;
    public event Action onMerchantIdle;

    public void ShowGameOver() => onShowGameOver?.Invoke();
    public void ShowVictory() => onShowVictory?.Invoke();   
    public void StartDialogue(string dialogueNode) => onStartDialogue?.Invoke(dialogueNode);
    public void StopCurrentDialogue() => onStopCurrentDialogue?.Invoke();
    public void GrandmaTalking() => onGrandmaTalking?.Invoke();
    public void GrandmaStoppingTalking() => onGrandmaStoppingTalking?.Invoke();
    public void MerchantIdle() => onMerchantIdle?.Invoke(); 
}
