using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{

    private Paddle paddle;
    //offset
    private Vector3 paddleToBallVector;
    private bool gameStarted = false;

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
                //need to access rigid body 2D velocity
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                gameStarted = true;
            }
        }//end if game has NOT started

    }


    //Methods hitFactor and OnCollisionEnter2D to calculate the Balls Direction
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
    {
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the Racket?
        if (col.gameObject.name == "Paddle")
        {
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            
            GetComponent<Rigidbody2D>().velocity = dir * 10f;
        }
    }

}//end of BallScript
