using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button settingsButton;
    [SerializeField]
    private Button exitButton;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        settingsButton.onClick.AddListener(Settings);
        exitButton.onClick.AddListener(ExitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
        // TODO: Fance animation where the camera leaves the main menu buttons and flies away to the game
    }

    void Settings()
    {
        Debug.Log("Open Settigns");
    }

    void ExitGame()
    {
        // TODO: pop up a dialog box to confirm exit
        Application.Quit();
    }
}
