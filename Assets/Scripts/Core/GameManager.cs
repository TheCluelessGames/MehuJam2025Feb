using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    public GameStates gameState;

    EventManager eventManager;
    DialogueRunner dialogueRunner;

    private void OnEnable()
    {
        eventManager = FindObjectOfType<EventManager>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();

        eventManager.onShowGameOver += SetGameOverState;
        eventManager.onStartDialogue += StartDialogue;
    }

    private void OnDisable()
    {
        eventManager.onShowGameOver -= SetGameOverState;
        eventManager.onStartDialogue -= StartDialogue;
    }

    private void Awake()
    {
        gameState = GameStates.Game;
    }

    public void SetGameOverState()
    {
        gameState = GameStates.GameOver;    
    }

    private void StartDialogue(string node)
    {
        dialogueRunner.StartDialogue(node);
    }
}
