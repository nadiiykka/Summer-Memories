using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class CheckMushroom : MonoBehaviour
{
    public TextMeshProUGUI message1;
    public TextMeshProUGUI message2;

    public Animator bearAnim;

    private int messageIndex1 = 0;
    private int messageIndex2 = 0;
    private bool isShowingInFirstField = true;

    private List<string> messages1 = new List<string>(); 
    private List<string> messages2 = new List<string>(); 

    void Start()
    {
        Time.timeScale = 1;

        bearAnim.enabled = false;

        Messages(); 
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
            if (messageIndex1 < messages1.Count)
            {
                message1.text = messages1[messageIndex1]; 
                messageIndex1++; 
            }
        }
        else
        {
            if (messageIndex2 < messages2.Count)
            {
                message2.text = messages2[messageIndex2]; 
                messageIndex2++;
            }
        }

        if (messageIndex1 >= messages1.Count && messageIndex2 >= messages2.Count)
        {
            LoadNextScene(); 

        }

        isShowingInFirstField = !isShowingInFirstField;
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
        while (messageIndex1 < messages1.Count || messageIndex2 < messages2.Count)
        {
            yield return null; 
        }
        SceneManager.LoadScene(10);
    }
}
