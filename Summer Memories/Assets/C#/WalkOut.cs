using TMPro;
using UnityEngine;

public class EnableAnimatorOnClick : MonoBehaviour
{
    private Animator animator; // Reference to the Animator component
    private bool isAnimatorEnabled = false; // Flag to check if the Animator is enabled

    public TextMeshProUGUI message1;

    private int messageIndex = 0;

    private void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();

        ShowNextMessage();

        // Initially disable the Animator
        if (animator != null)
        {
            animator.enabled = false;
        }
    }

    private void Update()
    {
        // Check for mouse click or screen tap
        if (Input.GetMouseButtonDown(0) && !isAnimatorEnabled)
        {
            messageIndex++; // Increment message index to show the next message
            ShowNextMessage();
        }
    }

    void ShowNextMessage()
    {
        // Display messages based on messageIndex
        if (messageIndex == 0)
        {
            message1.text = "Wow! Let's pick up some mushrooms. I'll look the other way";
        }
        else if (messageIndex == 1)
        {
            message1.text = "Collect all you see. You can choose the good ones later.";
        }

        // Enable the animator after displaying the second message
        if (messageIndex >= 2)
        {
            EnableAnimator();
        }
    }

    private void EnableAnimator()
    {
        if (animator != null && !isAnimatorEnabled)
        {
            animator.enabled = true; // Enable the Animator
            isAnimatorEnabled = true; // Update the flag to prevent further enabling
        }
    }
}
