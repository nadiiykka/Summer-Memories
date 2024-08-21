using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCheck : MonoBehaviour
{
    void Start()
    {
        CheckSavedTags();
    }

    void CheckSavedTags()
    {
        for (int i = 0; i < 10; i++)  // Припустимо, що у вас може бути до 10 слотів в інвентарі
        {
            string itemTag = PlayerPrefs.GetString("CollectedItem_" + i, "");

            if (itemTag == "Water")
            {
                Debug.Log("Player has water. Nothing happens.");
                // Тут нічого не робимо
            }
            else if (itemTag == "Book")
            {
                Debug.Log("Player has a book. Executing book actions...");
                ExecuteBookActions();
            }
        }
    }

    void ExecuteBookActions()
    {
        // Ваші дії, якщо гравець має предмет з тегом "book"
        Debug.Log("Player has a book. Executing book actions...");
        // Наприклад, відкриття дверей, показ повідомлення або зміна ігрових параметрів
    }
}
