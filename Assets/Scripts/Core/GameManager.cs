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
        eventManager.onShowVictory += SetVictoryState;
        eventManager.onStartDialogue += StartDialogue;
        eventManager.onStopCurrentDialogue += StopPreviousDialogue;
    }

    private void OnDisable()
    {
        eventManager.onShowGameOver -= SetGameOverState;
        eventManager.onStartDialogue -= StartDialogue;
        eventManager.onStopCurrentDialogue -= StopPreviousDialogue;
        eventManager.onShowVictory -= SetVictoryState;
    }

    private void Awake()
    {
        gameState = GameStates.Game;
    }

    public void SetGameOverState()
    {
        gameState = GameStates.GameOver;    
    }

    public void SetVictoryState()
    {
        gameState = GameStates.Victory; 
    }

    private void StartDialogue(string node)
    {
        dialogueRunner.StartDialogue(node);
    }

    private void StopPreviousDialogue()
    {
        dialogueRunner.Stop();
    }
}
