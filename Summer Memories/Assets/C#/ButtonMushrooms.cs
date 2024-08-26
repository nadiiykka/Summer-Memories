using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class ButtonMushrooms : MonoBehaviour
{
    public static bool anyNegativePickedUp = false; // Static flag for negative pickups (if needed elsewhere)
    public GameObject panel;

    public static int totalButtonClicks = 0; // Static variable to track the total number of button clicks

    public void PlusMushroom()
    {
        Debug.Log("Button clicked: Good Mushroom");
        
        IncrementButtonClickCount();
    }

    public void MinusMushroom()
    {
        Debug.Log("Button clicked: Bad Mushroom");
        anyNegativePickedUp = true;
        
        IncrementButtonClickCount();
    }

    private void IncrementButtonClickCount()
    {
        totalButtonClicks++; // Increment the total button click count

        if (totalButtonClicks >= 3)
        {
            LoadNextScene(); // Load the next scene after 3 clicks
        }
    }

    private void LoadNextScene()
    {
        // Assuming you want to load the next scene in the build order
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
