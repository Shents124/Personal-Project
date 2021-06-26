#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOver;
    public GameObject staminaUI;
    
    private bool isGamePaused = false;
    
    private void OnEnable()
    {
        EventBroker.GameOver += DisplayGameOver;
    }

    private void OnDisable()
    {
        EventBroker.GameOver -= DisplayGameOver;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused == false && pauseMenu.activeInHierarchy == false)
                PauseGame();
            else if(isGamePaused && pauseMenu.activeInHierarchy)
                ResumeGame();
        }
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOver.SetActive(false);
        staminaUI.SetActive(true);
    }
    
    private void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isGamePaused = true;
        staminaUI.SetActive(false);

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
        isGamePaused = false;
        staminaUI.SetActive(true);
        
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
    }
    
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
