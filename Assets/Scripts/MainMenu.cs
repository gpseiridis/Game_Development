using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    private int lives = 100;
    private int score = 0;
    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("CurrentLives", lives);
        PlayerPrefs.SetInt("Score", score);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

   
}
