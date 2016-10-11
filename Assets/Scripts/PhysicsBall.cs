using UnityEngine;
using System.Collections;

public class PhysicsBall : MonoBehaviour
{
    // Movement Speed
    public Rigidbody2D rb;
    public float speed = 100.0f;
    public float ballForce = 300;
    bool gameStarted = false;

    // Use this for initialization
    void Start()
    {


    }



    void Update()
    {

        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        if (Input.GetMouseButtonDown(0) && gameStarted == false)
        {
            transform.SetParent(null);
            rb.isKinematic = false;
            rb.AddForce(new Vector2(ballForce, ballForce), 0);
            gameStarted = true;
        }

    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
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
        if (col.gameObject.tag == "Paddle")
        {
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
}