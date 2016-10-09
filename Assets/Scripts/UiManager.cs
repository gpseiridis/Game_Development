using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

    public int lives;
    private int score;
    public Text scoreText;
    public Text livesText;
    public static UiManager instance = null;


    // Use this for initialization
    void Start () {
        lives = PlayerPrefs.GetInt("CurrentLives");
        score = PlayerPrefs.GetInt("CurrentScore");
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
    }
	
	// Update is called once per frame
	void Update () {
      
    }



    public void IncrementScore()
    {
     
        score++;
        //scoreText.text = "Score: " + score;
        scoreText.text = "Score: " + score;
        PlayerPrefs.SetInt("CurrentScore", score);
    }
    public void DecrementScore()
    {
        score--;
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score;
        PlayerPrefs.SetInt("CurrentScore", score);
    }
    public void DecrementLives()
    {
        
        lives--;
        livesText.text = "Lives: " + lives;
        PlayerPrefs.SetInt("CurrentLives", lives);
    }

}
