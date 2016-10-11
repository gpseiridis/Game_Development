using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string firstLevel;
    public int lives;
    public int score;

    public void NewGame()
    {
        PlayerPrefs.SetInt("CurrentLives", lives);
        PlayerPrefs.SetInt("CurrentScore", score);
        SceneManager.LoadScene(firstLevel);
        //Application.LoadLevel(level1);
      
    }

    public void QuitGame()
    {
        Debug.Log("Game closed");
        Application.Quit();
    }
}
