using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputPauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Shoot shoot;
    private void Start()
    {
        Resume();
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Debug.Log("test1");
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (GameIsPaused)
            {
                Resume();
            }
            else if (!GameIsPaused)
            {
                Pause();
            }
        }
        Debug.Log("test");
    }

    public void Resume()
    {
        shoot.canShoot = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
   
    void Pause()
    {
        shoot.canShoot = false; 
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void ReturnMenu()
    {
        Resume();
        Debug.Log("Retunr Menu...");
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void QuitGame()
    {

        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
