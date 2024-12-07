using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Start()
    {
        // Piilotetaan pause-valikko heti pelin alussa
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
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
        pauseMenuUI.SetActive(false);   // Piilotetaan pause-valikko
        Time.timeScale = 1f;            // Palautetaan pelin normaali nopeus
        GameIsPaused = false;           
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);    // N‰ytet‰‰n pause-valikko
        Time.timeScale = 0f;            // Pys‰ytet‰‰n peli
        GameIsPaused = true;           
    }

    // Aloittaa uuden pelin seuraavasta kohtauksesta
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;         
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;          
    }

    // Sammuttaa ohjelman, kun painetaan Quit-n‰pp‰int‰
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit");
    }

    // Palaa takaisin p‰‰valikkoon
    public void Main()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1.0f;         
    }
}
