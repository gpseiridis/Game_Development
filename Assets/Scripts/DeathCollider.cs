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

        //instead of game over, call decrement lives in the Level Manager
        // if out of lives, the Level Manager will be responsible to call game over
        Debug.Log("Collided!!!");
        // levelManager.LoadLevel("Game Over");
        levelManager.DecrementLives();

    }
}
