using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class ForestChat : MonoBehaviour
{
    public TextMeshProUGUI message1;
    public TextMeshProUGUI message2;

    private int messageIndex = 0;
    private bool isShowingInFirstField = true;

    void Start()
    {
        ShowNextMessage();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            ShowNextMessage();
        }
    }

    void ShowNextMessage()
    {
        if (isShowingInFirstField)
        {
            if (messageIndex == 0)
            {
                message1.text = "Hello! I already thought that u won´t come";
            }
            else if (messageIndex == 1)
            {
                message1.text = "What are you doing?";
            }
            else if (messageIndex == 2)
            {
                message1.text = "Sounds interesting!";
            }
            else if (messageIndex == 3)
            {
                message1.text = "I hope you're having fun!";
            }
        }
        else
        {
            if (messageIndex == 0)
            {
                message2.text = "Sorry";
            }
            else if (messageIndex == 1)
            {
                message2.text = "Just working on a project.";
            }
            else if (messageIndex == 2)
            {
                message2.text = "Yes, it really is!";
            }
            else if (messageIndex == 3)
            {
                message2.text = "I am, thank you!";
            }

            messageIndex = (messageIndex + 1) % 4; 
        }

        isShowingInFirstField = !isShowingInFirstField; 
    }

    public void SetMessage(int messageSlot, string newMessage, bool isMessage1)
    {
        if (isMessage1)
        {
            if (messageSlot == 0)
                message1.text = newMessage;
        }
        else
        {
            if (messageSlot == 0)
                message2.text = newMessage;
        }
    }
    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
