using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour {
    public UiManager ui;

    public string levelToLoad;
    public string nextLevel;
   

    // Use this for initialization
    void Start () {

       // NextLevel();
    }
	
	// Update is called once per frame
	void Update () {
      
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        
        ui = GameObject.FindWithTag("ui").GetComponent<UiManager>();
        
        /* int numOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
         print("Num of bricks print = " +numOfBricks);
         Debug.Log("Num of bricks log = " +numOfBricks);
         if (numOfBricks == 1)
         {
             SceneManager.LoadScene(nextLevel);
         }  */
       

        if (col.gameObject.tag == "Ball") {
            

            // numOfBricks = GameObject.FindGameObjectsWithTag("Enemy").Length;
            //print("Bricks num is currently:" + numOfBricks);
            ui.DecrementLives();
            ui.DecrementScore();
            if (ui.lives <0)
            {
                GameOver();
            }
            


            //this will restart the current scene. Decrease lives maybe! Then go to game over. I keep the comment as a future reference
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


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
        int currentScore= PlayerPrefs.GetInt("CurrentScore");
        currentScore++;
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        SceneManager.LoadScene(nextLevel);
        


       
    }
}
