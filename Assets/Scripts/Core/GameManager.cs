using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameStates gameState;

    EventManager eventManager;

    private void OnEnable()
    {
        eventManager = FindObjectOfType<EventManager>();

        eventManager.onShowGameOver += SetGameOverState;
    }

    private void OnDisable()
    {
        eventManager.onShowGameOver -= SetGameOverState;
    }

    private void Awake()
    {
        gameState = GameStates.Game;
    }

    public void SetGameOverState()
    {
        gameState = GameStates.GameOver;    
    }
}
