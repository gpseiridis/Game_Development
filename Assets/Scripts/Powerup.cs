using UnityEngine;
using System.Collections;



public class Powerup : MonoBehaviour {
    public Paddle paddle;


    // Use this for initialization
    void Start () {




    }
	
	// Update is called once per frame
	void Update () {

       


    }
    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.name == "DeathCollider")
        {
            Destroy(gameObject);
        }else if (coll.gameObject.name == "Paddle")
        {
            Debug.Log("TOUCHED THE PADDLE!!!");
            paddle.transform.localScale += new Vector3(2f, 0, 0);
            paddle.isBig = true;
            Destroy(gameObject);
        }
        else
        {

        }
        
    }

}
