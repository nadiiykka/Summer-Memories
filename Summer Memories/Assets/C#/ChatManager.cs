using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChatManager : MonoBehaviour
{
    public TextMeshProUGUI message1; // Text field 1
    public TextMeshProUGUI message2; // Text field 2

    public Animator animator1; // Animator for text field 1
    public Animator animator2; // Animator for text field 2

    public string[] messagesForMessage1; // Messages for text field 1
    public string[] messagesForMessage2; // Messages for text field 2

    private int messageIndex1 = 0; // Track current message index
    private int messageIndex2 = 0;
    private bool showInFirstField = true; // Toggle between text fields

    void Start()
    {
        ShowNextMessage(); // Show the first message at start
    }

    void Update()
    {
        // Check if there is at least one touch
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Check if the touch has just begun
            if (touch.phase == TouchPhase.Began)
            {
                ShowNextMessage(); // Show the next message on touch
            }
        }
    }

    void ShowNextMessage()
    {
        if (showInFirstField) 
        {
            if (messageIndex1 < messagesForMessage1.Length) 
            {
                message1.text = messagesForMessage1[messageIndex1]; // Display message in text field 1
                animator1.SetBool("IsUp", true); // Start upward animation
                animator2.SetBool("IsUp", false); // Ensure the other animator stays down
                messageIndex1++; 
            }
        }
        else
        {
            if (messageIndex2 < messagesForMessage2.Length)
            {
                message2.text = messagesForMessage2[messageIndex2]; // Display message in text field 2
                animator2.SetBool("IsUp", true); // Start upward animation
                animator1.SetBool("IsUp", false); // Ensure the other animator stays down
                messageIndex2++;
            }
        }

        showInFirstField = !showInFirstField; // Toggle field after displaying message

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
