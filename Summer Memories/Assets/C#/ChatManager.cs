using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ChatManager : MonoBehaviour
{
    public TextMeshProUGUI message1; 
    public TextMeshProUGUI message2; 

    public string[] messagesForMessage1; 
    public string[] messagesForMessage2; 

    private int messageIndex = 0;
    private bool isWaitingForClick = true;

    void Start()
    {
        ShowMessageInFirstField();
    }

    void Update()
    {
        if (isWaitingForClick && Input.GetMouseButtonDown(0))
        {
            isWaitingForClick = false;
            ShowMessageInSecondField();
        }
    }

    void ShowMessageInFirstField()
    {
        if (messageIndex < messagesForMessage1.Length)
        {
            message1.text = messagesForMessage1[messageIndex];
        }

        isWaitingForClick = true; 
    }

    void ShowMessageInSecondField()
    {
        if (messageIndex < messagesForMessage2.Length)
        {
            message2.text = messagesForMessage2[messageIndex];
        }

        StartCoroutine(ShowNextMessageAfterDelay(2f));
    }

    IEnumerator ShowNextMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 

        messageIndex++;

        if (messageIndex < messagesForMessage1.Length || messageIndex < messagesForMessage2.Length)
        {
            ShowMessageInFirstField(); 
        }
    }
}
