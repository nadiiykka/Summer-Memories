using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator cameraAnim;  // Прив'язка аніматора до камери
    public Animator phoneAnim;
    public float animationDuration = 2f;  // Задайте довжину анімації вручну

    public void LoadNextScene()
    {
        // Запускаємо корутину, яка чекає завершення анімації перед завантаженням сцени
        StartCoroutine(PlayAnimationAndLoadScene());
    }

    private IEnumerator PlayAnimationAndLoadScene()
    {
        // Запускаємо анімацію, встановлюючи параметр
        cameraAnim.SetFloat("Dialogue", 1.25f);

        // Чекаємо задану тривалість анімації
        yield return new WaitForSeconds(animationDuration);

        // Після завершення анімації завантажуємо наступну сцену
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

        phoneAnim.GetComponent<Animator>();
        cameraAnim.enabled = false;
    }

    // Цей метод викликається автоматично, коли нова сцена завантажена
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Знаходимо аніматор камери у новій сцені
        cameraAnim = FindObjectOfType<Camera>().GetComponent<Animator>();

        // Відписуємося від події, щоб уникнути помилок у майбутньому
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
