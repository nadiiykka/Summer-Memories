using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("CutScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void WinScene()
    {
        SceneManager.LoadScene("WinScene");
    }
}
