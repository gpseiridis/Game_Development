using UnityEngine;
using System.Collections;

public class DeathCollider : MonoBehaviour {

    private LevelManager levelManager;
    private Paddle paddle;
    private BallScript ball;
 

  //  public Powerup[] powerUpArray;
 
	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        paddle = GameObject.FindObjectOfType<Paddle>();
        ball = GameObject.FindObjectOfType<BallScript>();

    }
	
	// Update is called once per frame
	void Update () {
       
    }


    void OnCollisionEnter2D(Collision2D coll)
    {


        //instead of game over, call decrement lives in the Level Manager
        // if out of lives, the Level Manager will be responsible to call game over
        if (coll.gameObject.name == "Ball")
        {

       
        Debug.Log("Collided!!!");

        levelManager.DecrementLives();

        //making the ball go to the paddle everytime it hits the floor and start the game over
        
        ball.gameStarted = false;
        ball.paddleHitCounter = 0;
        
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball.wallAndBrickHitCounter = 0;
        ball.ballSpeed = 20f;
        paddle.transform.localScale = new Vector3(5f, 5f, 1f);




        }

    }




}
