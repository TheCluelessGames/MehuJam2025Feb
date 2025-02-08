using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public event Action onShowGameOver;

    public void ShowGameOver() => onShowGameOver?.Invoke();
}
