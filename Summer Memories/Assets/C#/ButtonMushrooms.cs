using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ButtonMushrooms : MonoBehaviour
{
    public static bool anyNegativePickedUp = false;
    public GameObject panel;

    private Button button;

    public static int totalButtonClicks = 0; 

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

        totalButtonClicks++; 

        if (totalButtonClicks >= 3)
        {
            LoadNextScene(); 
        }
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
