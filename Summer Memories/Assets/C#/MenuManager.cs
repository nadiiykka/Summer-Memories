using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int sceneIndex;
    public void StartGame()
    {
        if (sceneIndex == 0)
        {
            ButtonMushrooms.totalButtonClicks = 0;
            ButtonMushrooms.anyNegativePickedUp = false;
        }

        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Lopetit pelin.");
        Application.Quit();
    }
}
