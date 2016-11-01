using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{
    public int paddleHitCounter = 0;
    public int wallAndBrickHitCounter = 0;
    public bool gameStarted = false;
    public float ballSpeed = 20f;

    private Paddle paddle;
    //offset
    private Vector3 paddleToBallVector;



    private int maxSpeed = 50;


    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        paddle = FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
       
        if (!gameStarted)
        {
            //ball stay with the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;
   
            //left click or touch the screen
            if (Input.GetMouseButton(0))
            {

                GetComponent<Rigidbody2D>().velocity = new Vector2( ballSpeed-5, ballSpeed-5);                
                gameStarted = true;
            }
        }//end if game has NOT started

        //limiting the speed of the ball       
        if (ballSpeed >= maxSpeed)
        {
            
            ballSpeed = maxSpeed;

        }
        

    }


    //Methods hitFactor and OnCollisionEnter2D to calculate the Balls Direction
    float setDirectionX(Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
    {
        // ascii art:
        //
        // 1   -0.5   0   0.5   1    <- x value
        // ====|====|====|====|====  <- paddle
        //
        return (ballPos.x - paddlePos.x) / paddleWidth;
    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.name == "Paddle" && gameStarted)
        {
            paddleHitCounter++;
            //every 5 times the ball hits the paddle, its speed will increase
            if (paddleHitCounter % 5 == 0 )
            {

                ballSpeed += 5;
                
            }

               // Calculate direction in X
                float x = setDirectionX(transform.position, col.transform.position, col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;
            // Set Velocity with dir * speed
                        
            GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
         

          


    }//end checking hitting the paddle

        //incase the speed a little everytime it hits anything else
       if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Breakable" || col.gameObject.tag == "Unbreakable")
        {
            
                wallAndBrickHitCounter++;

                if (wallAndBrickHitCounter % 7 == 0)
                {
                    ballSpeed += 1f;



                }
           

            

        }//end checking hit wall or paddle


        // Extra physics when the ball hits something   
        Vector2 bounce = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));

        GetComponent<Rigidbody2D>().velocity += bounce;

  
    }// end checking collision2D

}//end of BallScript
