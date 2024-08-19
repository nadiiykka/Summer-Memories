using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChatManager : MonoBehaviour
{
    public Text message1; // Текстове поле для першого повідомлення
    public Text message2; // Текстове поле для другого повідомлення

    // Масиви для збереження повідомлень
    public string[] messagesForMessage1; // Повідомлення для першого текстового поля
    public string[] messagesForMessage2; // Повідомлення для другого текстового поля

    private int messageIndex = 0;
    private bool isWaitingForClick = true; // Змінна для контролю натискання

    void Start()
    {
        ShowMessageInFirstField(); // Показати перше повідомлення одразу після старту
    }

    void Update()
    {
        // Перевіряємо, чи користувач натиснув на екран і чи потрібно чекати на натискання
        if (isWaitingForClick && Input.GetMouseButtonDown(0))
        {
            isWaitingForClick = false;
            ShowMessageInSecondField();
        }
    }

    void ShowMessageInFirstField()
    {
        // Показуємо повідомлення у першому полі
        if (messageIndex < messagesForMessage1.Length)
        {
            message1.text = messagesForMessage1[messageIndex];
        }

        isWaitingForClick = true; // Очікуємо на наступне натискання
    }

    void ShowMessageInSecondField()
    {
        // Показуємо повідомлення у другому полі
        if (messageIndex < messagesForMessage2.Length)
        {
            message2.text = messagesForMessage2[messageIndex];
        }

        // Запускаємо корутину, щоб почекати кілька секунд і потім показати нове повідомлення у першому полі
        StartCoroutine(ShowNextMessageAfterDelay(2f));
    }

    IEnumerator ShowNextMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Очікування

        messageIndex++;

        if (messageIndex < messagesForMessage1.Length || messageIndex < messagesForMessage2.Length)
        {
            ShowMessageInFirstField(); // Показуємо наступне повідомлення у першому полі
        }
    }
}
