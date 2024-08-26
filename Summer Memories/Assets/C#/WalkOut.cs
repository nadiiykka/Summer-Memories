using UnityEngine;

public class EnableAnimatorOnClick : MonoBehaviour
{
    private Animator animator; // Reference to the Animator component
    private bool isAnimatorEnabled = false; // Flag to check if the Animator is enabled

    private void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();

        // Initially disable the Animator
        if (animator != null)
        {
            animator.enabled = false;
        }
        else
        {
            Debug.LogWarning("Animator component is missing from this GameObject.");
        }
    }

    private void Update()
    {
        // Check for mouse click or screen tap
        if (Input.GetMouseButtonDown(0) && !isAnimatorEnabled)
        {
            EnableAnimator();
        }
    }

    // Method to enable the Animator
    private void EnableAnimator()
    {
        if (animator != null)
        {
            animator.enabled = true; // Enable the Animator
            isAnimatorEnabled = true; // Update the flag
        }
    }
}
