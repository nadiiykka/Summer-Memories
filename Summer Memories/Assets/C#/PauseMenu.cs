using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public GameObject PausePanel;
    public AudioSource backgroundMusic; 
    public AudioSource backgroundMusic2; 

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        
        if (backgroundMusic != null && backgroundMusic2 != null)
        {
            backgroundMusic.Pause(); 
            backgroundMusic2.Pause(); 
        }
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;

        if (backgroundMusic != null && backgroundMusic2 != null)
        {
            backgroundMusic.Play();
            backgroundMusic2.Play();
        }
    }
    public void QuitGame()
    {
        Debug.Log("Lopetit pelin.");
        Application.Quit();
    }
}
