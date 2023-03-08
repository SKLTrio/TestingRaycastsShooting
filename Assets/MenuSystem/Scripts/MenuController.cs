using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    string playScene = "PlayerSandboxScene";

    [SerializeField]
    string mainMenuScene = "StartScene";

    [Tooltip("Drag in an options menu panel, if one exists.")]
    [SerializeField]
    GameObject optionsMenuPanel;

    [Tooltip("Drag in a pause menu panel, if one exists.")]
    [SerializeField]
    GameObject pauseMenuPanel;

    [Tooltip("Drag in a high scores panel, if one exists")]
    [SerializeField]
    GameObject HighScorePanel;

    [SerializeField]
    bool IsPauseMenuAvailable = false;

    [HideInInspector]
    public static bool IsGamePaused = false;

    void Update()
    {
        pauseMenu();
    }

    public void OptionsMenuClose()
    {
        optionsMenuPanel.SetActive(false);

    }

    public void OptionsMenuOpen()
    {
        optionsMenuPanel.SetActive(true);
    }

    void pauseMenu()
    {
        if (IsPauseMenuAvailable)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsGamePaused)
                {
                    Resume();
                }

                else
                {
                    Pause();
                }
            }
        }
    }

    void Pause()
    {
        Cursor.visible = true;
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;

    }

    public void Resume()
    {
        Cursor.visible = false;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    public void ReturnToMainMenu()
    {
        Resume();
        Cursor.visible = true;
        SceneManager.LoadScene(mainMenuScene);
    } 

    public void StartGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(playScene);

    }

    public void QuitGame()
    {
        Debug.Log("You have quit the game!");
        Application.Quit();
    }

    public void HighScoreMenuClose()
    {
        HighScorePanel.SetActive(false);
    }

    public void HighScoreMenuOpen()
    {
        HighScorePanel.GetComponent<HighScoreSystem>().UpdateHighScoreUI();
        HighScorePanel.SetActive(true);
    }

}
