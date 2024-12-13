using UnityEngine;
using TMPro; // For TextMeshPro

public class PlayerNameManager : MonoBehaviour
{
    public static PlayerNameManager Instance; // Singleton instance
    public string playerName = ""; // Store the player's name
    public TMP_InputField nameInputField; // Reference to the Input Field for the player name

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Method to be called when the user finishes entering their name
    public void OnNameEntered()
    {
        if (nameInputField != null)
        {
            playerName = nameInputField.text; // Get the text entered by the user
            Debug.Log("Player Name Set: " + playerName); // Optionally log the name
        }
    }

    // Method to retrieve the player name
    public string GetPlayerName()
    {
        return playerName;
    }
}
