using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class BrickScript : MonoBehaviour {
    //reference to the UI script
    public UiManager ui;
  // public Death death;

    public string nextLevel;
    // Use this for initialization
    void Start () {

        //Death death = GameObject.FindWithTag("Death").GetComponent<Death>();
        ui = GameObject.FindWithTag("ui").GetComponent<UiManager>();
       // death = GameObject.FindWithTag("Death").GetComponent<Death>();


    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D col)

    {
       
        if (col.gameObject.tag == "Ball")
        {
            //print("num of bricks = " + numOfBricks);
            
            ui.IncrementScore();
            Destroy(gameObject);
            // added this to make it bounce back. Left it commented in case I change my mind later
            // Destroy(gameObject, 0.1f); 

        
        }
      //  Death death = GameObject.FindWithTag("Death").GetComponent<Death>();
       int numOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        print("Num of bricks print = " + numOfBricks);
       Debug.Log("Num of bricks log = " + numOfBricks);
       if (numOfBricks <2) {
            //    death.NextLevel();
            GameObject.FindWithTag("Death").GetComponent<Death>().NextLevel();
        }
    }

}
