using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.IO;


public class UIManager : MonoBehaviour
{
    public Text currentScore;
    public Text highScoreText;
    public float scoreMultiplier;

    public GameObject startMenu;
    public GameObject pauseMenu;
    public GameObject hudMenu;
    private bool pause;
    private bool play;
    private int score;
    private int highScore;
    private string scoreFile;
    private string scoreFilePath;

    public void Awake(){
        
        Time.timeScale = 0;
        startMenu.SetActive(true);
        pauseMenu.SetActive(false);
        hudMenu.SetActive(false);
        scoreFilePath = Application.persistentDataPath +"/HighScore.json";
    }
    void Start()
    {
       if(!File.Exists(scoreFilePath)){
        CreateFilePath();
       } else {
         highScore = GetHighScore();
         highScoreText.text = highScore.ToString();
       }
         
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && play){
            pause = !pause;
            Pause(pause);
        }
        Score();
        if(score>highScore){
            highScore = score;
            highScoreText.text = highScore.ToString();
        }
    }

    public void Score(){
        score = Mathf.RoundToInt(scoreMultiplier * Time.time);
        currentScore.text = score.ToString();
    }

    public void Play(){
        Time.timeScale = 1;
        startMenu.SetActive(false);
        play = true;
        hudMenu.SetActive(true);
    }

    public void Pause(bool pause){
        pauseMenu.SetActive(pause);
        if(pause){
            Time.timeScale = 0;
        }else {
            Time.timeScale = 1;
        }
    }

    public void Continue(){
        Time.timeScale = 1;
        pause = !pause;
        Pause(pause);
    }

    public void Restart(){
        score = 0;
        SetHighScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }

    public void Quit(){
        Application.Quit();
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif    
        score = 0;
        SetHighScore();
    }

    public int GetHighScore(){        
        scoreFile = File.ReadAllText(scoreFilePath);
        HighScore hscore = JsonUtility.FromJson<HighScore>(scoreFile);
        return hscore.score;       
    }

    public void SetHighScore(){
        HighScore hscore = new HighScore();
        hscore.score = highScore;
        string json = JsonUtility.ToJson(hscore);
        File.WriteAllText(scoreFilePath, json);
    }

    public void CreateFilePath(){
        using(FileStream fs = File.Create(scoreFilePath)){
            Debug.Log(fs);
        }
    }
}
[Serializable]
public class HighScore{
    public int score;
}