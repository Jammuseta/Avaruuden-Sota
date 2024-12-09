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
    public void AddScore(int newScore, string newName)
    {
        int[] scores = new int[MaxEntries];
        string[] names = new string[MaxEntries];

        // Retrieve existing leaderboard data
        for (int i = 0; i < MaxEntries; i++)
        {
            scores[i] = PlayerPrefs.GetInt($"Score{i}");
            names[i] = PlayerPrefs.GetString($"Name{i}");
        }

        // Insert the new score and name into the leaderboard
        for (int i = 0; i < MaxEntries; i++)
        {
            if (newScore > scores[i])
            {
                // Shift lower scores down
                for (int j = MaxEntries - 1; j > i; j--)
                {
                    scores[j] = scores[j - 1];
                    names[j] = names[j - 1];
                }

                // Insert the new score
                scores[i] = newScore;
                names[i] = newName;
                break;
            }
        }

        // Save updated leaderboard
        for (int i = 0; i < MaxEntries; i++)
        {
            PlayerPrefs.SetInt($"Score{i}", scores[i]);
            PlayerPrefs.SetString($"Name{i}", names[i]);
        }
        PlayerPrefs.Save();

        DisplayLeaderboard(); // Refresh the UI
    }

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
