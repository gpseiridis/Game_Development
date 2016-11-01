using UnityEngine;
using System.Collections;



public class Powerup : MonoBehaviour {
    private Paddle paddle;
    private BallScript ball;
    private BrickScript[] bricks;

    // Use this for initialization
    void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        ball = GameObject.FindObjectOfType<BallScript>();

        bricks = GameObject.FindObjectsOfType<BrickScript>();
       
        //powerUp should ignore the ball and all the bricks
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), ball.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), ball.GetComponent<Collider2D>());
        foreach (BrickScript brick in bricks)
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), brick.GetComponent<Collider2D>());
        }

    }
	
	// Update is called once per frame
	
    void Update () {


    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.name == "DeathCollider")
        {
            Destroy(gameObject);

        }
        else if (coll.gameObject.name == "Paddle")
        {
            Debug.Log("TOUCHED THE PADDLE!!!");
            if (paddle.transform.localScale.x <= 5)
            {
                paddle.transform.localScale += new Vector3(2f, 0, 0);
                paddle.isBig = true;
            }

            Destroy(gameObject);

        }

        else
        {
            //TODO
        }
    }

    
}
