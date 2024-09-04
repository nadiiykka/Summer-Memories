using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public TextMeshProUGUI timerText;
    public float gameTime;

    public GameObject crosses;
    public GameObject items;

    private bool stopTimer;
    private bool timerStarted = false; 

    private float startTime;

    void Start()
    {
        stopTimer = false;
        crosses.SetActive(true);
        items.SetActive(true);
        
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    void Update()
    {
        if (timerStarted && !stopTimer)
        {
            float time = gameTime - (Time.time - startTime);

            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);

            string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            if (time <= 0)
            {
                stopTimer = true;
                TimeIsUp();
            }

            timerText.text = textTime;
            timerSlider.value = time;
        }
    }

    public void StartTimer()
    {
        if (!timerStarted)
        {
            timerStarted = true;
            startTime = Time.time;
        }
    }

    public void TimeIsUp()
    {
        crosses.SetActive(false);
        items.SetActive(false);
        Scene currentScene = SceneManager.GetActiveScene();
        int currentIndex = currentScene.buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }
}
