using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [Header("Main Menu Buttons")]
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button settingsButton;
    [SerializeField]
    private Button exitButton;

    [Header("Sound Effects")]
    [SerializeField]
    private AudioClip buttonClickSound;
    [SerializeField]
    private AudioClip buttonHoverSound;

    [Header("Virtual Camera")]
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;


    private void Start()
    {
        // play animation on virtual camera
        virtualCamera.GetComponent<Animator>().Play("CameraMainMenu");

        // play hover and click sound for every button
        startButton.onClick.AddListener(() => startButton.GetComponent<AudioSource>().PlayOneShot(buttonClickSound));
        settingsButton.onClick.AddListener(() => settingsButton.GetComponent<AudioSource>().PlayOneShot(buttonClickSound));
        exitButton.onClick.AddListener(() => exitButton.GetComponent<AudioSource>().PlayOneShot(buttonClickSound));

        // Start Button
        startButton.onClick.AddListener(StartGame);

        // Settings Button
        settingsButton.onClick.AddListener(Settings);

        // Exit Button
        exitButton.onClick.AddListener(ExitGame);
    }

    private void startHoverSound(Button button)
    {
        button.GetComponent<AudioSource>().PlayOneShot(buttonHoverSound);
        // change mouse cursor to hover
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void HoverSoundStart()
    {
        startHoverSound(startButton);
    }

    public void HoverSoundSettings()
    {
        startHoverSound(settingsButton);
    }

    public void HoverSoundExit()
    {
        startHoverSound(exitButton);
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
