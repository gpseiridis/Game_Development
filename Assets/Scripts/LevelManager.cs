using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour {

    //to xw public gia na vlepw na miwnetai
    private int lives;
    
    private int highScore;

    public int score;
    public int continuousBricks = 0;
    public Text livesText;
    public Text scoreText;
    public Text highScoreText;

    void Start()
    {
       
        lives = PlayerPrefs.GetInt("CurrentLives");
        score = PlayerPrefs.GetInt("Score", score);
        StoreHighscore(0);



        livesText.text = "Lives: " + lives;
        scoreText.text = "SCORE " + score;
  

    }
    public void LoadLevel(string name) {
        scoreText.text = "SCORE " + score;
        Application.LoadLevel(name);
       // SceneManager.LoadScene(name);
    }

    public void QuitRequest() {
        Debug.Log("Game eXited");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        PlayerPrefs.SetInt("CurrentLives", lives);
        PlayerPrefs.SetInt("Score", score);

        //pass level based on the build settings and index.
        // level 1 ---> level 2 ---> .... ---> level N ---> Win Screen
        Application.LoadLevel(Application.loadedLevel + 1);
       // SceneManager.LoadScene(Application.loadedLevel + 1 );
    }

    public void BrickDestroyed()
    {
        continuousBricks+=25;
        IcreaseScore();
        if (BrickScript.bricks <=0)
        {
            LoadNextLevel();

        }
    }

    
    //logiki... decrement lives kai tha kalite apo to DeathCollider!
    public void DecrementLives()
    {

        lives--;
        continuousBricks += 0;
        PlayerPrefs.SetInt("CurrentLives", lives);
       
        if (lives<= 0)
        {
            GameOver();
        }
       
        livesText.text = "Lives: " + lives;
        
       
    }

    public void IcreaseScore()
    {
        Debug.Log("extra score is " + continuousBricks);
        score += 100+continuousBricks;
        PlayerPrefs.SetInt("Score", score);
        scoreText.text = "SCORE " + score;

        StoreHighscore(score);

    }

    public void StoreHighscore(int newHighscore)
    {
        int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
        if (newHighscore > oldHighscore)
            PlayerPrefs.SetInt("highscore", newHighscore);

        highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");
        Debug.Log("lives!!!--> " + lives);
        

    }

    public void GameOver()
    {
        
        LoadLevel("Game Over");
        
    }


}//end level manager
