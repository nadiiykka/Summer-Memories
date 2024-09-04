using UnityEngine;

public class MoveRoom : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public Animator animator; 

    public float minX; 
    public float maxX; 

    public VariableJoystick variableJoystick; 

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool facingRight = true; 

    private Timer timer; 
    private bool hasMoved = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        movement.x = variableJoystick.Horizontal;
        movement.y = variableJoystick.Vertical;

        if (!hasMoved && (movement.x != 0 || movement.y != 0))
        {
            hasMoved = true;
            if (timer != null) {
                timer.StartTimer();
            }
        }

        animator.SetFloat("Speed", movement.sqrMagnitude);

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
        Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        rb.MovePosition(newPosition);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
