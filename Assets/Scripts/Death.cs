using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour {

    public string levelToLoad;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball") {
            // game over
             SceneManager.LoadScene(levelToLoad);
            //this will restart the current scene. Decrease lives maybe! Then go to game over
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
