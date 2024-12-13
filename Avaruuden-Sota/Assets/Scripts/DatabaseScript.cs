using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class database : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts; // Array to display scores (assign in Inspector)
    public TextMeshProUGUI[] nameTexts;  // Array to display names (assign in Inspector)

    private const int MaxEntries = 5; // Top 5 scores

    void Start()
    {
        InitializeLeaderboard(); // Create default leaderboard if needed
        DisplayLeaderboard();   // Show the data on the scoreboard
    }

    // Initializes default leaderboard data if not already present
    private void InitializeLeaderboard()
    {
        if (!PlayerPrefs.HasKey("Score0")) // Check if leaderboard exists
        {
            // Create default leaderboard
            for (int i = 0; i < MaxEntries; i++)
            {
                PlayerPrefs.SetInt($"Score{i}", 0);
                PlayerPrefs.SetString($"Name{i}", "Player");
            }
            PlayerPrefs.Save();
        }
    }

    // Updates the leaderboard with a new score and name
    

    // Displays the leaderboard on the scoreboard
    public void DisplayLeaderboard()
    {
        for (int i = 0; i < MaxEntries; i++)
        {
            int score = PlayerPrefs.GetInt($"Score{i}");
            string name = PlayerPrefs.GetString($"Name{i}");

            scoreTexts[i].text = score.ToString(); // Display score
            nameTexts[i].text = name;             // Display name
        }
    }
}
