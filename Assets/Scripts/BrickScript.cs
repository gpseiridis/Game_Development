using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D col)

    {
        if (col.gameObject.tag == "Ball")
        {
           // Destroy(gameObject);
           // added this to make it bounce back. Left it commented in case I change my mind later
            Destroy(gameObject, 0.2f); 
        }
    }
}
