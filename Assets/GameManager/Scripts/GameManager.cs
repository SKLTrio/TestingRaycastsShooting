using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // The Design Pattern: Singleton

    public static GameManager Instance { get; private set; }
    public UIManager UIManager { get; private set; }
    public HighScoreSystem HighScoreSystem { get; private set; }

    private static float secondsSincestart = 0;
    public static int score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;

        }

        Instance = this;

        UIManager = GetComponent<UIManager>();
        HighScoreSystem = GetComponent<HighScoreSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        secondsSincestart += Time.deltaTime;
        Instance.UIManager.UpdateTimeUI(secondsSincestart);

    }

    public static string GetScoreText()
    {
        return score.ToString();
    }

    public static void IncrementScore(int value)
    {

        score += value;
        Instance.UIManager.UpdateScoreUI(score);
        Debug.Log("Score: " + score);

    }

    public static void ResetGame()
    {

        ResetScore();
        secondsSincestart = 0f;
        Time.timeScale = 1f;

    }

    public static void ResetScore()
    {

        score = 0;
        Instance.UIManager.UpdateScoreUI(score);
        Debug.Log("Score: " + score.ToString());

    }

    public void GameOver()
    {
        Time.timeScale = 1f;
        MenuController.IsGamePaused = true;

        Instance.UIManager.ActivateEndGame(score);
        HighScoreSystem.CheckHighScore("Anon", score);

    }
}
