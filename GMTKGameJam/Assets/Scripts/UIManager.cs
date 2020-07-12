using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    float score;
    public Text scoreUI;
    public Text finalScoreUI;

    public GameObject startScreen;
    public GameObject inGameScreen;
    public GameObject pauseScreen;
    public GameObject endScreen;

    GameManager gameManager;

    void Start()
    {
        score = 0f;
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        score += Time.deltaTime*gameManager.gameSpeed;
        scoreUI.text = Mathf.Round(score).ToString();
    }

    private void OnEnable()
    {
        PlayerController.ObjectHit += OnGameOver;
    }

    private void OnDisable()
    {
        PlayerController.ObjectHit -= OnGameOver;
    }

    public void OnStartButtonClick()
    {
        score = 0f;
        Time.timeScale = 1;

        gameManager.OnGameStart();
        startScreen.SetActive(false);
        inGameScreen.SetActive(true);
    }

    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void OnResumeButtonClick()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void OnRestartButtonClick()
    {
        score = 0f;
        gameManager.OnGameStart();

        pauseScreen.SetActive(false);
        endScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnGameOver(string s)
    {
        Time.timeScale = 0;
        finalScoreUI.text = "Distance covered: " + Mathf.Round(score).ToString();
        endScreen.SetActive(true);
    }

    public void OnQuitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }
}

