using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public event Action onShowGameOver;
    public event Action<string> onStartDialogue;

    public void ShowGameOver() => onShowGameOver?.Invoke();
    public void StartDialogue(string dialogueNode) => onStartDialogue?.Invoke(dialogueNode);
}
