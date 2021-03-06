using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject bigWavesText;
    public GameObject levelCompletedText;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }

            else 
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        bigWavesText.SetActive(false);
        levelCompletedText.SetActive(false);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void QuitGame()
    {
        IsPaused = false;
        Time.timeScale = 0f;
        SceneManager.LoadScene("MenuScene");
    }
}
