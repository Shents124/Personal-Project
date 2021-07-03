#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOver;
    public GameObject staminaUI;
    public GameObject controllerUI;
    
    private void OnEnable()
    {
        EventBroker.GameOver += DisplayGameOver;
    }

    private void OnDisable()
    {
        EventBroker.GameOver -= DisplayGameOver;
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOver.SetActive(false);
        staminaUI.SetActive(true);
        controllerUI.SetActive(true);
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

        AudioSource[] audioSource = FindObjectsOfType<AudioSource>();
        foreach (var item in audioSource)
        {
            item.Pause();
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

        AudioSource[] audioSource = FindObjectsOfType<AudioSource>();
        foreach (var item in audioSource)
        {
            item.Play();
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        ResumeGame();
    }

    private void DisplayGameOver()
    {
        gameOver.SetActive(true);
        staminaUI.SetActive(false);
        controllerUI.SetActive(false);
        AudioSource[] audioSource = FindObjectsOfType<AudioSource>();
        foreach (var item in audioSource)
        {
            item.Stop();
        }
    }
    
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
