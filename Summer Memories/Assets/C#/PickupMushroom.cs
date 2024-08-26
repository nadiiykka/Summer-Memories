using UnityEngine;

public class PickupMushroom : MonoBehaviour
{
    public GameObject panel; // Reference to the panel UI GameObject

    private static int i; // Static variable to track the number of pickups

    

    private void Start()
    {
        panel.SetActive(false); // Initially hide the panel
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Increment the static counter
            i++;

            // Destroy the mushroom GameObject
            Destroy(gameObject);
            
            if (i >= 10)
            {
                panel.SetActive(true); // Show the panel after 10 pickups
                Time.timeScale = 0;
            }
        }
    }
}
