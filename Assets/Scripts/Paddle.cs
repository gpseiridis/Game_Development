using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 paddlePosition = new Vector3(0.5f, this.transform.position.y, 0f);

        float mousePosition = Input.mousePosition.x / Screen.width * 16;

        //Mathf.clamp to restric the position of my paddle
        paddlePosition.x = Mathf.Clamp(mousePosition, 1.4f, 14.56f);
        this.transform.position = paddlePosition;

    }
}
