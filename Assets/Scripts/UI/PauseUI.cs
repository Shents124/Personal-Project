#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    private bool isGamePaused = false;
    public GameObject pauseMenu;
    public GameObject gameOver;

    private void OnEnable()
    {
        EventBroker.GameOver += DisplayGameOver;
    }

    private void OnDisable()
    {
        EventBroker.GameOver -= DisplayGameOver;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused == false)
                PauseGame();
            else
                ResumeGame();
        }
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOver.SetActive(false);
    }
    
    private void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isGamePaused = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        ResumeGame();
    }

    private void DisplayGameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
    }
    
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
