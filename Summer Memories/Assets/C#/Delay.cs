using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections; 

public class Delay : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadNextSceneAfterDelay(7f));
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                LoadNextScene();
            }
        }
    }

    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        LoadNextScene();
    }

    void LoadNextScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        int nextSceneIndex = currentScene.buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more scenes to load.");
        }
    }
}
