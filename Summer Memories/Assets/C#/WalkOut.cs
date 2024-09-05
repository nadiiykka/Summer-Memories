using TMPro;
using UnityEngine;

public class EnableAnimatorOnClick : MonoBehaviour
{
    private Animator animator;
    private bool isAnimatorEnabled = false; 

    public TextMeshProUGUI message1;

    private int messageIndex = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();

        ShowNextMessage();

        if (animator != null)
        {
            animator.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAnimatorEnabled)
        {
            messageIndex++; 
            ShowNextMessage();
        }
    }

    void ShowNextMessage()
    {
        if (messageIndex == 0)
        {
            message1.text = "Wow! Let's pick up some mushrooms. I'll look the other way";
        }
        else if (messageIndex == 1)
        {
            message1.text = "Collect all you see. You can choose the good ones later.";
        }

        if (messageIndex >= 2)
        {
            EnableAnimator();
        }
    }

    private void EnableAnimator()
    {
        if (animator != null && !isAnimatorEnabled)
        {
            animator.enabled = true; 
            isAnimatorEnabled = true; 
        }
    }
}
