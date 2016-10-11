using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour
{
    public UiManager ui;

    public string levelToLoad;
    public string nextLevel;


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {


        ui = GameObject.FindWithTag("ui").GetComponent<UiManager>();
        

        if (col.gameObject.tag == "Ball")
        {

            
            ui.DecrementLives();
            ui.DecrementScore();
            if (ui.lives < 0)
            {
                GameOver();
            }



        }
    }
    void GameOver()
    {
        SceneManager.LoadScene(levelToLoad);

    }
    public void NextLevel()
    {
        print("PRINT Next level triggered");
        Debug.Log("LOG Next level triggered");
        int numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        print("Number of bricks PRINT " + numberOfBricks);
        Debug.Log("Number of bricks LOG " + numberOfBricks);


        //  Load next level, increase score + 1 cause for some reason it was -1
        int currentScore = PlayerPrefs.GetInt("CurrentScore");
        currentScore++;
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        SceneManager.LoadScene(nextLevel);




    }
}