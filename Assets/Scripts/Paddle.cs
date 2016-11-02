using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public bool automatic = false;
    public bool isBig = false;

    private BallScript ball;
    private float bigPaddle;
    

    // Use this for initialization
    void Start() {
        ball = GameObject.FindObjectOfType<BallScript>();
        print(ball);
    }

    // Update is called once per frame
    void Update() {

        if (!automatic) {
            MouseMove();
        }
        else
        {
            AutomaticPlay();
        }
        
        //for restricting the paddle going out of the boundaries
        if (isBig)
        {
            bigPaddle = 0.9f;

        }
        else
        {
            bigPaddle = 0f;
        }

    }

    void MouseMove()
    {
        Vector3 paddlePosition = new Vector3(0.5f, this.transform.position.y, 0f);

        float mousePosition = Input.mousePosition.x / Screen.width * 16;
        
        //Mathf.clamp to restric the position of my paddle
        paddlePosition.x = Mathf.Clamp(mousePosition, 1.95f + bigPaddle, 14.06f - bigPaddle);
        this.transform.position = paddlePosition;

    }
    void AutomaticPlay()
    {
        // most is same with what we do with mouse, but we ask PC to do it for us now
        
        Vector3 paddlePosition = new Vector3(0.5f, this.transform.position.y, 0f);

        //float mousePosition = Input.mousePosition.x / Screen.width * 16;    
        Vector3 ballPosition = ball.transform.position;

        paddlePosition.x = Mathf.Clamp(ballPosition.x, 2.0f, 14.01f);
        this.transform.position = paddlePosition;
    }
   
}
