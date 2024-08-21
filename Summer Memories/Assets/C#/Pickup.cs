using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;

                    // Збереження тегу у PlayerPrefs
                    string itemTag = gameObject.tag;
                    PlayerPrefs.SetString("CollectedItem_" + i, itemTag);
                    PlayerPrefs.Save();

                    Instantiate(itemButton, inventory.slots[i].transform, false); // Спавнимо кнопку для взаємодії
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
