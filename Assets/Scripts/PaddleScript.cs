using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    public float maxX;
    public bool screenTouch = false;
    public UiManager ui;

    // Use this for initialization
    void Start()
    {
        ui = GameObject.FindWithTag("ui").GetComponent<UiManager>();
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
    void OnCollisionEnter2D(Collision2D col)

    {
        if (col.gameObject.tag == "Ball")
        {
            ui.DecrementScore();
        }
    }
}// end