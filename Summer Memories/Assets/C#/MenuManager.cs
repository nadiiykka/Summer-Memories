using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int sceneIndex;
    public void StartGame()
    {
        SceneManager.LoadScene(sceneIndex);
        ButtonMushrooms.totalButtonClicks = 0;
    }

    public void QuitGame()
    {
        Debug.Log("Lopetit pelin.");
        Application.Quit();
    }
}
