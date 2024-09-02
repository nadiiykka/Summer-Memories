using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management
using System.Collections; // Required for IEnumerator

public class Delay : MonoBehaviour
{
    void Start()
    {
        // Start the coroutine to load the next scene after a delay
        StartCoroutine(LoadNextSceneAfterDelay(7f)); // 10 seconds delay
    }

    // Coroutine to load the next scene after a specified delay
    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delay);

        // Load the next scene
        LoadNextScene();
    }

    // Method to load the next scene
    void LoadNextScene()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Calculate the next scene index
        int nextSceneIndex = currentScene.buildIndex + 1;

        // Check if the next scene index is within the valid range
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // Optionally handle the case where there are no more scenes to load
            Debug.Log("No more scenes to load.");
        }
    }
}
