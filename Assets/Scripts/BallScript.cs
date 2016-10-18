using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{
    public int paddleHitCounter = 0;
    public bool gameStarted = false;

    private Paddle paddle;
    //offset
    private Vector3 paddleToBallVector;    
    public Vector2 ballSpeed = new Vector2(15, 15);
    
    private float directedSpeed = 20f;
   

    // Use this for initialization
    void Start()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
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
                
                GetComponent<Rigidbody2D>().velocity = ballSpeed;
                gameStarted = true;
            }
        }//end if game has NOT started

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
        // Check if hit the Paddle
        if (col.gameObject.name == "Paddle")
        {
            paddleHitCounter++;
            //every 5 times the ball hits the paddle, its speed will increase
            if (paddleHitCounter % 5 == 0 )
            {
                ballSpeed.x += 3f;
                ballSpeed.y += 3f;
                directedSpeed += 7;

            }
            else if(!gameStarted)
            {
                ballSpeed.x = 15f;
                ballSpeed.y = 15f;
                directedSpeed = 20f;
            }
           
            
        

                // Calculate direction in X
                float x = setDirectionX(transform.position, col.transform.position, col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;
            // Set Velocity with dir * speed
                        
            GetComponent<Rigidbody2D>().velocity = dir * directedSpeed;


        }//end checking hitting the paddle


        // I want to add some extra physics when the ball hits something
        Vector2 bounce = new Vector2(Random.Range(0f, 1.5f), Random.Range(0f, 1.5f));
        





        if (gameStarted)
        {
            GetComponent<Rigidbody2D>().velocity += bounce;
        }
    

    }

}//end of BallScript
