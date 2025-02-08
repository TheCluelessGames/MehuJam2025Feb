using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_ScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;

    EventManager eventManager;

    private void OnEnable()
    {
        eventManager = FindObjectOfType<EventManager>();

        eventManager.onShowGameOver += OpenGameOverScreen;
    }

    private void OnDisable()
    {
        eventManager.onShowGameOver -= OpenGameOverScreen;
    }

    // Start is called before the first frame update
    void Awake()
    {
        gameOverScreen.SetActive(false);

        restartButton.onClick.AddListener(()
            => RestartLevel());
        menuButton.onClick.AddListener(()
            => MenuButton());
    }

    private void OpenGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    private void RestartLevel()
    {
        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;
        SceneManager.LoadScene(currentSceneName);
    }

    private void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
