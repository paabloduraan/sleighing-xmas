using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameHandler : MonoBehaviour
{

    public GameObject divider;
    public GameObject scoreText;
    private int playerScore = 0;
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public int count = 0;


    void Start()
    {
        divider = GameObject.Find("Divider");
        pauseMenuUI.SetActive(false);
        GameisPaused = false;
    }

    public void AddScore(int points)
    {
        playerScore += points;
        UpdateScore();
    }

    void UpdateScore()
    {
        Text scoreTextB = scoreText.GetComponent<Text>();
        scoreTextB.text = "" + playerScore;
    }

    void Update (){
        if (Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log(count);
                if (GameisPaused){
                        divider.SetActive(true);
                        Resume();
                }
                else{
                    divider.SetActive(false);
                    Pause();
                }
        }
    }

    public void RestartGame(){
               Time.timeScale = 1f;
               // Add commands to zero-out any scores or other stats before restarting
               SceneManager.LoadScene("Level1");
    }

    void Pause(){
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameisPaused = true;
    }

    public void Resume(){
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameisPaused = false;
    }

    public void QuitGame(){
          #if UNITY_EDITOR
          UnityEditor.EditorApplication.isPlaying = false;
          #else
          Application.Quit();
          #endif
      }

    public void StartGame() {
          SceneManager.LoadScene("Level1");
    }

    public void EndGame() {
          SceneManager.LoadScene("EndPage");
    }
}
