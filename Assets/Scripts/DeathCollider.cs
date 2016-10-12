using UnityEngine;
using System.Collections;

public class DeathCollider : MonoBehaviour {

    private LevelManager levelManager;
	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
       
    }


    void OnCollisionEnter2D(Collision2D coll)
    {

        Debug.Log("Collided!!!");
        levelManager.LoadLevel("Game Over");

    }
}
