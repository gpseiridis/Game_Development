using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

    int score = 0;
    public int lives = 3;
    public Text scoreText;
    public Text livesText;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       // livesText.text = "Lives: " + lives;
    }
    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
    public void DecrementScore()
    {
        score--;
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score;
    }
    public void DecrementLives()
    {
        lives--;
        livesText.text = "Lives: " + lives;
    }

}
