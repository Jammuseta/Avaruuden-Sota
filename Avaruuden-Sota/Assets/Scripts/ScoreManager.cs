using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        // Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public void Start()
    {
        scoreText.text = "Score: 0";
        score = 0;
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText == null)
        {
            Debug.LogError("ei toimi;)");
            return;
        }
        
        scoreText.text = "Score: " + score;
    }
    public int GetFinalScore()
    {
        return score;
    }
}
