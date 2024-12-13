using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameIsOver = false;
    public GameObject pauseMenuUI;
    public addscores targetScript;
    public database display;
    void Start()
    {
        // Piilotetaan pause-valikko heti pelin alussa
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (!GameIsOver)  // Jos peli ei ole p‰‰ttynyt, voidaan k‰sitell‰ pause-Canvasta
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
        int finalScore = ScoreManager.Instance.GetFinalScore();
        string playerName = PlayerNameManager.Instance.GetPlayerName();
        GameIsOver = false;
        SceneManager.LoadScene("SampleScene");
        targetScript.AddScore(finalScore, playerName);
        Time.timeScale = 1.0f;
        finalScore = 0;
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
        int finalScore = ScoreManager.Instance.GetFinalScore();
        string playerName = PlayerNameManager.Instance.GetPlayerName();
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1.0f;
        targetScript.AddScore(finalScore, playerName);     
    }
}
