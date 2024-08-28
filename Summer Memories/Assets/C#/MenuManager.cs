using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int sceneIndex;
    public void StartGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Lopetit pelin.");
        Application.Quit();
    }
}
