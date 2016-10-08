using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed;
    public float maxX;
    public bool screenTouch =false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        float y_pos = 95.5f;

       
        if(Input.GetMouseButtonDown(0))
        {
            screenTouch = true;
           
        }
        if (screenTouch != false) { 
       
            Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, y_pos);
            Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            transform.position = curPosition;

        }

        float x = Input.GetAxis("Horizontal");

        //movement
        if (x == 0)
        {
            Stop();
        }
        else if (x > 0)
        {
            MoveRight();
        }
        else if(x <0)
        {
            MoveLeft();
        }
        //restrict the movement outside boundaries
        Vector3 pos = transform.position;
        pos.x= Mathf.Clamp(pos.x, -maxX, maxX);
        transform.position = pos;

    }

    void MoveLeft()
    {
        rb.velocity = new Vector2(-speed, 0);
    }
    void MoveRight()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    void Stop()
    {
        rb.velocity = Vector2.zero;
    }
   
    
}
