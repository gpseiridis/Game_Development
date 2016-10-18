using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    private int lives = 7;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("CurrentLives", lives);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

   
}
