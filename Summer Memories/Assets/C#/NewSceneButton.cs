using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator cameraAnim;  
    public Animator phoneAnim;
    public float animationDuration = 1.3f;  

    public void LoadNextScene()
    {
        StartCoroutine(PlayAnimationAndLoadScene());
    }

    private IEnumerator PlayAnimationAndLoadScene()
    {
        cameraAnim.SetFloat("Dialogue", 1.25f);

        yield return new WaitForSeconds(animationDuration);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

        phoneAnim.GetComponent<Animator>();
        cameraAnim.enabled = false;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        cameraAnim = FindObjectOfType<Camera>().GetComponent<Animator>();

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
