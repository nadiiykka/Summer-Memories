using UnityEngine;

public class PickupMushroom : MonoBehaviour
{
    public GameObject panel; 

    private static int i; 

    

    private void Start()
    {
        panel.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            i++;

            Destroy(gameObject);
            
            if (i >= 10)
            {
                panel.SetActive(true);
                Time.timeScale = 0;

                i = 0;
            }
        }
    }
}
