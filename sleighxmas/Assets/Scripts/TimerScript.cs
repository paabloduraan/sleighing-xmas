using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public GameObject number1;
    public GameObject number2;
    public GameObject number3;

    public Image divider;

    void Start()
    {
        divider.enabled = false;
        TimerOn = true;
        Time.timeScale = 0f;
    }

    void Update()
    {
        if(TimerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.unscaledDeltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
                number1.SetActive(false);
                number2.SetActive(false);
                number3.SetActive(false);
                divider.enabled = true;
                Time.timeScale = 1f;
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        if (seconds == 3) {
            number1.SetActive(false);
            number2.SetActive(false);
            number3.SetActive(true);
        }
        else if (seconds == 2) {
            number1.SetActive(false);
            number2.SetActive(true);
            number3.SetActive(false);
        }
        else if (seconds == 1) {
            number1.SetActive(true);
            number2.SetActive(false);
            number3.SetActive(false);
        }
    }

}
