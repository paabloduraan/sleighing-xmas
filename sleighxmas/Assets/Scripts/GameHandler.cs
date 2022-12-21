using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class GameHandler : MonoBehaviour
{

    public GameObject scoreText;
    public GameObject scoreText2;
    public static int playerScore = 0;
    public static int playerScore2 = 0;
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public int count = 0;
    public AudioMixer mixer;
    public static float volumeLevel = 1.0f;
    private Slider sliderVolumeCtrl;
    public bool winner = true;


    void Start()
    {
        UpdateScore();
        UpdateScore2();
        pauseMenuUI.SetActive(false);
        GameisPaused = false;
    }

    void Awake (){
               SetLevel (volumeLevel);
               GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
               if (sliderTemp != null){
                       sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                       sliderVolumeCtrl.value = volumeLevel;
               }
       }
    public void AddScore(int points)
    {
        playerScore += points;
        if (playerScore < 0) {
            playerScore = 0;
        }
        UpdateScore();
    }

    void UpdateScore()
    {
        Text scoreTextB = scoreText.GetComponent<Text>();
        scoreTextB.text = "" + playerScore;
    }

    public void AddScore2(int points)
    {
        playerScore2 += points;
        if (playerScore2 < 0) {
            playerScore2 = 0;
        }
        UpdateScore2();
    }

    void UpdateScore2()
    {
        Text scoreTextB = scoreText2.GetComponent<Text>();
        scoreTextB.text = "" + playerScore2;
    }

    public void SetLevel (float sliderValue){
              mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
              volumeLevel = sliderValue;
      }

      void Update (){
        if (Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log(count);

            Debug.Log("escape");
            Debug.Log("escape1");

                if (GameisPaused){
                    Debug.Log("resume1");

                        Resume();
                        Debug.Log("resume2");

                }
                else{
                    Debug.Log("pause1");

                        Pause();
                        Debug.Log("pause2");

                }
        }
    }

    public void RestartGame(){
               Time.timeScale = 1f;
               // Add commands to zero-out any scores or other stats before restarting
               SceneManager.LoadScene("StartPage");
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

    public void Instructions() {
          SceneManager.LoadScene("Instructions");
    }

    public void BackToStart() {
          SceneManager.LoadScene("StartPage");
    }

    public void higherScore() {
          if (playerScore > playerScore2) {winner = true;}
          else {winner = false;};
          playerScore = 0;
          playerScore2 = 0;
    }
}
