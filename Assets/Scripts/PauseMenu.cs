using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    [SerializeField] private GameObject pause;


    /*// Update is called once per frame
    void Update()
    {
        if (initiatePause)
        {
            if (isGamePaused)
            {
                Resume();
                
            }
            else
            {
                
            }
        }
    }*/

    public void PauseGame()
    {
        Pause();
    }
    public void ResumeGame()
    {
        Resume();
    }

    public void RestartGame()
    {
        Restart();
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    void Resume()
    {
        gameObject.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    void Pause()
    {
        gameObject.SetActive(true);
        pause.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
}
