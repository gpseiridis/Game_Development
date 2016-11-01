using UnityEngine;
using System.Collections;



public class Powerup : MonoBehaviour {
    private Paddle paddle;
    private BallScript ball;
    private BrickScript[] bricks;
    private string[] typesOfPowerups = { "enlarge", "spawnballs" };
    private int index;
   



    // Use this for initialization
    void Start () {
        //TODO:
        //1. make an algorithm to spawn 2 kind of powerUps...
        //   one orange and one blue (find their hex in the pallete)
        //2. make some sort of Switch case...  
        //   ftiakse enan pinaka me typesOfPowerups = ["enlarge","spawnBalls"] 
        //if(Random.Range(0, chanceToInvoke) == 0 )
        index = Random.Range(0, typesOfPowerups.Length);
        //Debug.Log("randomed index --> " + index);
        switch (typesOfPowerups[index])
        {
            //COLOURING
            case "enlarge":
                Debug.Log("Enlarge me plz --> " +index);
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case "spawnballs":
                Debug.Log("Let there be BALLZ! --> " + index);
                //0BDD40FF
                // gameObject.GetComponent<Renderer>().material.color = Color.green;
                gameObject.GetComponent<Renderer>().material.color = new Color32(11, 221, 65, 255);
                break;


        }
       


        //// end of getting random powerup
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
            /*
            Debug.Log("TOUCHED THE PADDLE!!!");
            if (paddle.transform.localScale.x <= 5)
            {
                paddle.transform.localScale += new Vector3(2f, 0, 0);
                paddle.isBig = true;
            }

            Destroy(gameObject);
            
        */
            switch (typesOfPowerups[index])
            {

                case "enlarge":

                    EnlargePaddle();
                    break;

                case "spawnballs":

                    SpawnBalls();
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


    void SpawnBalls()
    {
        if(paddle.transform.localScale.x > 5)
        {
            paddle.transform.localScale = new Vector3(5f, 5f, 1f);
            paddle.isBig = false;
        }
        Destroy(gameObject);
    }
    
}
