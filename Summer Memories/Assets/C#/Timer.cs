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

    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        crosses.SetActive(true);
        items.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float time = gameTime - Time.time;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes % 60);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if( time <= 0)
        {
            stopTimer = true;
            TimeIsUp();
        }
        if ( stopTimer == false)
        {
            timerText.text = textTime;
            timerSlider.value = time;
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
