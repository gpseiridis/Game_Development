using UnityEngine;
using System.Collections;

public class DeathCollider : MonoBehaviour {

    private LevelManager levelManager;
    private Paddle paddle;
    private BallScript ball;


    public Powerup powerup;


    //  public Powerup[] powerUpArray;

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        paddle = GameObject.FindObjectOfType<Paddle>();
        ball = GameObject.FindObjectOfType<BallScript>();
        //powerup = GameObject.FindObjectOfType<Powerup>();
    }
	
	// Update is called once per frame
	void Update () {
       
    }


    void OnCollisionEnter2D(Collision2D coll)
    {

        //the ball should go back to paddle only if both the ORIGINAL ball and the CLONE ball are destroyed
        if (coll.gameObject.name == "Ball")
        {
            //IF just the Ball was hit, then simply 'make it disappear'
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //original 2-2-1
            ball.transform.localScale = new Vector3(0, 0, 0);

            //if there are no clones, then make it go back to paddle, decrease lives

           
        Debug.Log("Collided!!!");
          
            // Destroy(powerup);
        Destroy(GameObject.Find("powerup(Clone)"));
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
