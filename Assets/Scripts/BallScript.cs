using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public Rigidbody2D rb;
    public float ballForce;
    public float ballSpeed;
    bool gameStarted = false;

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = rb.velocity.normalized * ballSpeed;
        if (Input.GetKeyUp(KeyCode.Space) && gameStarted == false){
            
            transform.SetParent(null);
            rb.isKinematic = false;
            rb.AddForce(new Vector2(ballForce, ballForce),0);
            gameStarted = true;

        }
	
	}
}
