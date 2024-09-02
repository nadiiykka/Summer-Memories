using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public GameObject PausePanel;
    public AudioSource backgroundMusic; 

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        
        if (backgroundMusic != null)
        {
            backgroundMusic.Pause(); 
        }
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;

        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
    }
}
