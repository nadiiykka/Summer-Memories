using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator cameraAnim;  // Прив'язка аніматора до камери

    public void LoadNextScene()
    {
        // Підписуємося на подію завершення завантаження сцени
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Завантажуємо наступну сцену
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // Цей метод викликається автоматично, коли нова сцена завантажена
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Встановлюємо параметр анімації у новій сцені
        cameraAnim = FindObjectOfType<Camera>().GetComponent<Animator>();
        cameraAnim.SetFloat("Dialogue", 1.25f);

        // Відписуємося від події, щоб уникнути помилок у майбутньому
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
