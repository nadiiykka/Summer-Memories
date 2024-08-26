using UnityEngine;

public class ChooseMushroom : MonoBehaviour
{
    private PickupMushroom currentMushroom;
    public GameObject panel;

    // Method to set the current triggered mushroom
    public void SetCurrentMushroom(PickupMushroom mushroom)
    {
        currentMushroom = mushroom;
    }

    // When "Collect" is pressed
    public void CollectMushroom()
{
    // Close the panel
    panel.SetActive(false);

    // Resume game time
    Time.timeScale = 1;

    // Destroy the mushroom GameObject that was triggered
    if (currentMushroom != null)
    {
        Destroy(currentMushroom.gameObject);  // Destroy the GameObject, not just the component
    }
}


    // When "Cancel" is pressed
    public void CancelMushroom()
    {
        
            // Just close the panel and resume the game
            panel.SetActive(false);
            Time.timeScale = 1;
        
    }
}
