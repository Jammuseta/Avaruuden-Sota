using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addscores : MonoBehaviour
{
    private const int MaxEntries = 5;
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
    }
}
