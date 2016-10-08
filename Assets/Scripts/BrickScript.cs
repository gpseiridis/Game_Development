using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {
    //reference to the UI script
    public UiManager ui;

	// Use this for initialization
	void Start () {
        ui = GameObject.FindWithTag("ui").GetComponent<UiManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D col)

    {
        if (col.gameObject.tag == "Ball")
        {
            ui.IncrementScore();
            Destroy(gameObject);
           // added this to make it bounce back. Left it commented in case I change my mind later
           // Destroy(gameObject, 0.1f); 
        }
    }
}
