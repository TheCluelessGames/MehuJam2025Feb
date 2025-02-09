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

    public void ShowGameOver() => onShowGameOver?.Invoke();
    public void ShowVictory() => onShowVictory?.Invoke();   
    public void StartDialogue(string dialogueNode) => onStartDialogue?.Invoke(dialogueNode);
    public void StopCurrentDialogue() => onStopCurrentDialogue?.Invoke();
}
