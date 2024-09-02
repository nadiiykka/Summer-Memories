using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Required for scene management

public class CheckMushroom : MonoBehaviour
{
    public TextMeshProUGUI message1;
    public TextMeshProUGUI message2;

    public Animator bearAnim;

    private int messageIndex1 = 0;
    private int messageIndex2 = 0;
    private bool isShowingInFirstField = true;

    private List<string> messages1 = new List<string>(); // List of messages for message1
    private List<string> messages2 = new List<string>(); // List of messages for message2

    void Start()
    {
        Time.timeScale = 1;

        bearAnim.enabled = false;

        Messages(); // Initialize messages
        ShowNextMessage(); // Show the first message
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShowNextMessage(); // Show the next message on mouse click
        }
    }

    void ShowNextMessage()
    {
        if (isShowingInFirstField)
        {
            // Check if there are more messages to display in the first field
            if (messageIndex1 < messages1.Count)
            {
                message1.text = messages1[messageIndex1]; // Set text for message1
                messageIndex1++; // Update index for the next message
            }
        }
        else
        {
            // Check if there are more messages to display in the second field
            if (messageIndex2 < messages2.Count)
            {
                message2.text = messages2[messageIndex2]; // Set text for message2
                messageIndex2++; // Update index for the next message
            }
        }

        // Check if all messages have been displayed
        if (messageIndex1 >= messages1.Count && messageIndex2 >= messages2.Count)
        {
            // Only call LoadNextScene if no other script has already triggered it

            LoadNextScene(); // Load the next scene if all messages are done

        }

        isShowingInFirstField = !isShowingInFirstField; // Switch between display fields
    }

    void LoadNextScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int currentIndex = currentScene.buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

    void Messages()
    {
        messages1.Add("Did you any find good mushrooms?");
        messages2.Add("Of course, I'm not an expert, but I think these are nice");
        messages1.Add("Well, show me!");

        messages2.Add("Here they are");

        if (ButtonMushrooms.anyNegativePickedUp)
        {
            messages1.Add("Oh no! These are poisonous.");
            messages2.Add("No way!!!");

            bearAnim.enabled = true;

            messages1.Add("Look, a bear right there.");
            messages2.Add("AAA");

            StartCoroutine(ShowMessagesAndLoadScene());
            return;
        }
        else
        {
            messages1.Add("Great! These are really nice.");
            messages2.Add("Yeeeey!!!");
        }
        messages1.Add("Nice!");
    }

    IEnumerator ShowMessagesAndLoadScene()
    {
        // Wait for messages to be displayed
        while (messageIndex1 < messages1.Count || messageIndex2 < messages2.Count)
        {
            yield return null; // Wait for the next frame
        }
        SceneManager.LoadScene(10);
    }
}
