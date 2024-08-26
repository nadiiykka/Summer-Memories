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
    private bool timerStarted = false; // Add this to check if the timer has started

    private float startTime; // Store the time when the timer starts

    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;
        crosses.SetActive(true);
        items.SetActive(true);
        
        // Initialize the timer slider but don't start the timer yet
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted && !stopTimer)
        {
            // Update the time remaining
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
            startTime = Time.time; // Record the time when the timer starts
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
