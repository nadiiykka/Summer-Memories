using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChatManager : MonoBehaviour
{
    public TextMeshProUGUI message1; 
    public TextMeshProUGUI message2; 

    public Animator animator1; 
    public Animator animator2; 

    public string[] messagesForMessage1; 
    public string[] messagesForMessage2; 

    private int messageIndex1 = 0; 
    private int messageIndex2 = 0;
    private bool showInFirstField = true; 

    void Start()
    {
        ShowNextMessage();
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
        if (showInFirstField) 
        {
            if (messageIndex1 < messagesForMessage1.Length) 
            {
                message1.text = messagesForMessage1[messageIndex1];
                animator1.SetBool("IsUp", true); 
                animator2.SetBool("IsUp", false); 
                messageIndex1++; 
            }
        }
        else
        {
            if (messageIndex2 < messagesForMessage2.Length)
            {
                message2.text = messagesForMessage2[messageIndex2]; 
                animator2.SetBool("IsUp", true); 
                animator1.SetBool("IsUp", false); 
                messageIndex2++;
            }
        }

        showInFirstField = !showInFirstField;

        if (messageIndex1 >= messagesForMessage1.Length && messageIndex2 >= messagesForMessage2.Length) 
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(currentSceneIndex + 1); 
    }
}
