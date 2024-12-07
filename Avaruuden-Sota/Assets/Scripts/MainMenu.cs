using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Valitsee build asetuksista Scenejen indexist‰ oikean
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //Sammuttaa ohjelman, kun painaa main menussa quit n‰pp‰int‰ ja se l‰hett‰‰ consoliin viestin, ett‰ tiedet‰‰n, ett‰ se toimii
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit");
    }
}
