using UnityEngine;

public class MoveRoom : MonoBehaviour
{
    public float moveSpeed = 5f; // Швидкість руху персонажа
    public Animator animator; // Посилання на компонент Animator

    public float minX; // мінімальна координата X, яку може зайняти персонаж
    public float maxX; // максимальна координата X, яку може зайняти персонаж

    public VariableJoystick variableJoystick; // Reference to the joystick

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool facingRight = true; // Визначає, чи дивиться персонаж вправо

    private Timer timer; // Reference to the Timer script
    private bool hasMoved = false; // To check if the player has moved

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        // Obtain joystick input
        movement.x = variableJoystick.Horizontal;
        movement.y = variableJoystick.Vertical;

        // Check if the player has started moving
        if (!hasMoved && (movement.x != 0 || movement.y != 0))
        {
            hasMoved = true;
            timer.StartTimer(); // Start the timer when the player first moves
        }

        // Update animation parameters
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Flip character based on direction
        if (movement.x < 0 && facingRight)
        {
            Flip();
        }
        else if (movement.x > 0 && !facingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // Calculate the new position based on joystick input
        Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        // Clamp the character's position within minX and maxX
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Move the character
        rb.MovePosition(newPosition);
    }

    // Function to flip the character along the X-axis
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1; // Invert the X axis for flipping
        transform.localScale = scaler;
    }
}
