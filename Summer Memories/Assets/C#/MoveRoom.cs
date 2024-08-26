using UnityEngine;

public class MoveRoom : MonoBehaviour
{
    public float moveSpeed = 5f; // Швидкість руху персонажа
    public Animator animator; // Посилання на компонент Animator

    public float minX; // мінімальна координата X, яку може зайняти персонаж
    public float maxX; // максимальна координата X, яку може зайняти персонаж

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool facingRight = true; // Визначає, чи дивиться персонаж вправо

    private Timer timer; // Reference to the Timer script
    private bool hasMoved = false; // To check if the player has moved

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Find and assign the Timer script
        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        // Отримання вводу від користувача
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Check if the player has started moving
        if (!hasMoved && (movement.x != 0 || movement.y != 0))
        {
            hasMoved = true;
            timer.StartTimer(); // Start the timer when the player first moves
        }

        // Оновлення анімаційних параметрів
        animator.SetFloat("Speed", movement.sqrMagnitude); // Швидкість використовується для перевірки руху

        // Відзеркалення персонажа при русі вліво/вправо
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
        // Отримання нової позиції персонажа
        Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        // Обмежуємо рух персонажа за X між minX і maxX
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Переміщення персонажа
        rb.MovePosition(newPosition);
    }

    // Функція для відзеркалення персонажа по осі X
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1; // Змінюємо знак на осі X для відзеркалення
        transform.localScale = scaler;
    }
}
