using UnityEngine;
using System.Collections;



public class Powerup : MonoBehaviour {
    private Paddle paddle;
    private BallScript ball;
    private BrickScript[] bricks;
    private DeathCollider deathCollider;
    private string[] typesOfPowerups = { "slowDown", "enlarge" };
    private int index;



    // Use this for initialization
    void Start() {
        paddle = GameObject.FindObjectOfType<Paddle>();
        ball = GameObject.FindObjectOfType<BallScript>();
        deathCollider = GameObject.FindObjectOfType<DeathCollider>();
        bricks = GameObject.FindObjectsOfType<BrickScript>();

        ChoosePowerUp();

    }
	

    void ChoosePowerUp()
    {


       // index = Random.Range(0, typesOfPowerups.Length);
       //more chances for spawning enlarge powerup
        if(Random.Range(0, 10) <=5 )
        {
            index = 1;
        }
        else
        {
            index = 0;
        }
        Debug.Log("randomed index --> " + index);
        switch (typesOfPowerups[index])
        {
            //COLOURING
            case "enlarge":
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        
                break;
            case "slowDown":
                gameObject.GetComponent<Renderer>().material.color = new Color32(11, 221, 65, 255);               
    
                break;


        }
  
        //powerUp should ignore the ball and all the bricks
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), ball.GetComponent<Collider2D>());
        foreach (BrickScript brick in bricks)
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), brick.GetComponent<Collider2D>());
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.name == "DeathCollider")
        {
            Destroy(gameObject);

        }
        else if (coll.gameObject.name == "Paddle")
        {


            switch (typesOfPowerups[index])
            {
                
                case "slowDown":
  
                    SlowDown();
                break;

                case "enlarge":                 
                     EnlargePaddle();
                 break;


            }
        }


        else
        {
            //TODO
        }
    }

    void EnlargePaddle()
    {
        Debug.Log("TOUCHED THE PADDLE!!!");
        if (paddle.transform.localScale.x <= 5)
        {
            paddle.transform.localScale += new Vector3(2f, 0, 0);
            paddle.isBig = true;
        }

        Destroy(gameObject);

    }


    void SlowDown()
    {


        if (paddle.transform.localScale.x > 5)
        {
            paddle.transform.localScale = new Vector3(5f, 5f, 1f);
            paddle.isBig = false;

        }



            Debug.Log("Too fast");
            ball.GetComponent<Rigidbody2D>().velocity = ball.GetComponent<Rigidbody2D>().velocity / 1.8f;
            ball.ballSpeed = 20f;

        Destroy(gameObject);
        





    }
    
}
