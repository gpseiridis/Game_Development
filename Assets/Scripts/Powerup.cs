using UnityEngine;
using System.Collections;



public class Powerup : MonoBehaviour {
    private Paddle paddle;
    private BallScript ball;
    private BrickScript[] bricks;
    private DeathCollider deathCollider;
    //basika adi gia spawnballs, kane to na kanei thn taxuthta tis balas pio siga!
    private string[] typesOfPowerups = { "spawnballs", "enlarge" };
    private bool cloneInvoked = true;

    private int index=-1;




    // Use this for initialization
    void Start() {


        ChoosePowerUp();
    }
	
	// Update is called once per frame
	
    void Update () {


     
       

    }

    void ChoosePowerUp()
    {

        if (!cloneInvoked)
        {
            Debug.Log("look!! clone invoked -->" + cloneInvoked);

        index = Random.Range(0, typesOfPowerups.Length);

        }
        else
        {
            index = 1;
            
        }
        if (index == 0)
        {
            cloneInvoked = true;
           
         
           
        }

       // Debug.Log("randomed index --> " + index);
        switch (typesOfPowerups[index])
        {
            //COLOURING
            case "enlarge":
          
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case "spawnballs":
                

                // gameObject.GetComponent<Renderer>().material.color = Color.green;
                gameObject.GetComponent<Renderer>().material.color = new Color32(11, 221, 65, 255);
                break;


        }



        //// end of getting random powerup
        paddle = GameObject.FindObjectOfType<Paddle>();
        ball = GameObject.FindObjectOfType<BallScript>();
        deathCollider = GameObject.FindObjectOfType<DeathCollider>();

        bricks = GameObject.FindObjectsOfType<BrickScript>();

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
                
                case "spawnballs":
                    //cloneInvoked = true;
                    SpawnBalls();
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


    void SpawnBalls()
    {


        if (paddle.transform.localScale.x > 5)
        {
            paddle.transform.localScale = new Vector3(5f, 5f, 1f);
            paddle.isBig = false;

        }
        //GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
        Destroy(gameObject);
        //Instantiate(ball, ball.transform.position, ball.transform.rotation);
        // BallScript ballClone = (BallScript)Instantiate(ball, ball.transform.position, ball.transform.rotation);
        

        
        BallScript ballClone= (BallScript) Instantiate(ball, ball.transform.position, ball.transform.rotation);
        ballClone.GetComponent<Renderer>().material.color = Color.red;
        Physics2D.IgnoreCollision(ballClone.GetComponent<Collider2D>(), ball.GetComponent<Collider2D>());
        deathCollider.noClones = false;
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), ballClone.GetComponent<Collider2D>());





    }
    
}
