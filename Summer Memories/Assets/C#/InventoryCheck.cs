﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InventoryCheck : MonoBehaviour
{
    public TextMeshProUGUI message1;
    public TextMeshProUGUI message2;

    private int messageIndex1 = 0;
    private int messageIndex2 = 0;
    private bool isShowingInFirstField = true;

    private List<string> messages1 = new List<string>(); // Список повідомлень для message1
    private List<string> messages2 = new List<string>(); // Список повідомлень для message2

    void Start()
    {
        CheckSavedTags(); // Додати всі необхідні повідомлення в списки
        ShowNextMessage(); // Показати перше повідомлення
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ShowNextMessage();
            }
        }
    }

    void ShowNextMessage()
    {
        if (isShowingInFirstField)
        {
            if (messageIndex1 < messages1.Count)
            {
                message1.text = messages1[messageIndex1]; // Встановити текст для message1
                messageIndex1++; // Оновити індекс для наступного повідомлення
            }
        }
        else
        {
            if (messageIndex2 < messages2.Count)
            {
                message2.text = messages2[messageIndex2]; // Встановити текст для message2
                messageIndex2++; // Оновити індекс для наступного повідомлення
            }
        }

        isShowingInFirstField = !isShowingInFirstField; // Перемикання між полями відображення

        // Check if all messages have been displayed
        if (messageIndex1 >= messages1.Count && messageIndex2 >= messages2.Count)
        {
            LoadNextScene(); // Load the next scene if all messages are done
        }
    }

    void LoadNextScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int currentIndex = currentScene.buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

    void CheckSavedTags()
    {
        bool hasWater = false;
        bool hasBread = false;
        bool hasFish = false;
        bool hasCamera = false;
        bool hasCactus = false;
        bool hasAid = false;
        bool hasBook = false;

        int inventorySize = PlayerPrefs.GetInt("InventorySize", 4); // Отримання розміру інвентарю

        for (int i = 0; i < inventorySize; i++)
        {
            string itemTag = PlayerPrefs.GetString("CollectedItem_" + i, "");

            if (itemTag == "Water")
            {
                hasWater = true;
            }
            else if (itemTag == "Bread")
            {
                hasBread = true;
            }
            else if (itemTag == "Fish")
            {
                hasFish = true;
            }
            else if (itemTag == "Camera")
            {
                hasCamera = true;
            }
            else if (itemTag == "Cactus")
            {
                hasCactus = true;
            }
            else if (itemTag == "Aid")
            {
                hasAid = true;
            }
            else if (itemTag == "Book")
            {
                hasBook = true;
            }
        }

        messages1.Add("Hello! I didn't expect you to really pack things up so quickly!");
        messages1.Add("You were in a hurry, surely you didn't forget anything important?");
        messages1.Add("Well, I hope you took water and food.");

        messages2.Add("I'm glad to see you too!");
        messages2.Add("Hold on, like what?");

        if ((!hasWater && !hasBread) || (!hasWater && !hasFish))
        {
            messages2.Add("Oops.");
            messages1.Add("REALLY? It had to be at the top of your list.");
            messages2.Add("What do I do...");

            StartCoroutine(ShowMessagesAndLoadScene()); // Start coroutine to show messages and load scene
            return; // Exit the method to prevent adding more messages
        }
        else if ((!hasWater && hasBread) || (!hasWater && hasFish) || (hasWater && !hasBread) || (hasWater && !hasFish))
        {
            messages2.Add("Oops. Only one of that...");
            messages1.Add("Omg. You are lucky that you have me, I will share with you.");
        }
        else if ((hasWater && hasBread) || (hasWater && hasFish))
        {
            messages2.Add("How could I. It was at the top of my list.");
            messages1.Add("Thank God!");
        }

        messages2.Add("I didn't have enough time!");
        messages1.Add("Sorry! So, what else did u take?");

        if (hasCamera)
        {
            messages2.Add("Camera! We need to have nice pics.");
            messages1.Add("WOW! Super!");
        }
        if (hasCactus)
        {
            messages2.Add("Cactus! ");
            messages1.Add("WHAT?");
            messages2.Add("I couldn't leave him alone!!!");
            messages1.Add("Sometimes I wonder how you live in this world.?");
        }
        if (hasAid)
        {
            messages2.Add("First Aid Kit");
            messages1.Add("Oh yes! I hope it won't be useful to us.");
        }
        if (hasBook)
        {
            messages2.Add("Just a book I'm reading");
            messages1.Add("I don't really think u'll have time for reading");
            messages2.Add("I always have time for reading!!!");
            messages1.Add("I know haha");
        }

        messages2.Add("Okaaaay! Let's go, I think");
        messages1.Add("Let's goooo!!!");
    }

    IEnumerator ShowMessagesAndLoadScene()
    {
        // Wait for messages to be displayed
        while (messageIndex1 < messages1.Count || messageIndex2 < messages2.Count)
        {
            yield return null; // Wait for the next frame
        }

        // Load the specific scene after messages are shown
        SceneManager.LoadScene(10);
    }
}
