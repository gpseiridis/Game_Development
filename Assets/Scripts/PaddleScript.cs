using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    public float maxX;
    public bool screenTouch = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float y_pos = 120f;

      
        print("transform pos = " + transform.position);
        if (Input.GetMouseButtonDown(0))
        {
            screenTouch = true;

        }
        if (screenTouch != false)
        {
         
            Vector2 currScreenPoint = new Vector2(Input.mousePosition.x, y_pos);
            Vector2 currPosition = Camera.main.ScreenToWorldPoint(currScreenPoint);
            transform.position = currPosition;

        }




    }
}