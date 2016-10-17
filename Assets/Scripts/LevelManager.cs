﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour {

    //to xw public gia na vlepw na miwnetai
    private int lives;
    public Text livesText;

    void Start()
    {
       
        lives = PlayerPrefs.GetInt("CurrentLives");
        livesText.text = "Lives: " + lives;

    }
    public void LoadLevel(string name) {

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

        //pass level based on the build settings and index.
        // level 1 ---> level 2 ---> .... ---> level N ---> Win Screen
         Application.LoadLevel(Application.loadedLevel + 1);
       // SceneManager.LoadScene(Application.loadedLevel + 1 );
    }

    public void BrickDestroyed()
    {
        if (BrickScript.bricks <=0)
        {
            LoadNextLevel();
        }
    }

    
    //logiki... decrement lives kai tha kalite apo to DeathCollider!
    public void DecrementLives()
    {

        lives--;
        PlayerPrefs.SetInt("CurrentLives", lives);
       
        if (lives<= 0)
        {
            GameOver();
        }
       
        livesText.text = "Lives: " + lives;
        
       
    }

    public void GameOver()
    {
        LoadLevel("Game Over");
    }


}//end level manager