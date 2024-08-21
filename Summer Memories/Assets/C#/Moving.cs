using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 2f;
    private float jumpingPower = 3f;
    private bool isFacingRight = true;

    public float minX; // мінімальна координата X, яку може зайняти персонаж
    public float maxX; // максимальна координата X, яку може зайняти персонаж

    public Animator animator; // Посилання на компонент Animator
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        // Отримуємо горизонтальний ввід
        horizontal = Input.GetAxisRaw("Horizontal");

        // Оновлюємо анімаційний параметр Speed для перемикання між анімаціями
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        // Стрибок
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        // Зменшення швидкості під час відпускання кнопки стрибка
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        // Відзеркалення персонажа при русі вліво/вправо
        Flip();
    }

    private void FixedUpdate()
    {
        // Рух персонажа
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        // Отримуємо поточну позицію персонажа
        Vector3 clampedPosition = transform.position;

        // Обмежуємо координату X між minX та maxX
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);

        // Оновлюємо позицію персонажа
        transform.position = clampedPosition;
    }

    private bool IsGrounded()
    {
        // Перевірка, чи персонаж на землі
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        // Перевірка на зміну напрямку руху
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Trigger"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            int currentIndex = currentScene.buildIndex;
            SceneManager.LoadScene(currentIndex + 1);
        }
    }
}
