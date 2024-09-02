using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ButtonMushrooms : MonoBehaviour
{
    public static bool anyNegativePickedUp = false; // Static flag for negative pickups (if needed elsewhere)
    public GameObject panel;

    private Button button;

    public static int totalButtonClicks = 0; // Static variable to track the total number of button clicks

    public void PlusMushroom()
    {
        Debug.Log("Button clicked: Good Mushroom");
        
        IncrementButtonClickCount();

        OnButtonClick();
    }

    public void MinusMushroom()
    {
        Debug.Log("Button clicked: Bad Mushroom");
        anyNegativePickedUp = true;
        
        IncrementButtonClickCount();

        OnButtonClick();
    }

    private void IncrementButtonClickCount()
    {

        totalButtonClicks++; // Increment the total button click count

        if (totalButtonClicks >= 3)
        {
            LoadNextScene(); // Load the next scene after 3 clicks
        }
    }
    void OnButtonClick()
    {
       button = GetComponent<Button>();

        button.gameObject.SetActive(false);
    }

    private void LoadNextScene()
    {
        // Assuming you want to load the next scene in the build order
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
