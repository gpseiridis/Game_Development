using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {

    public int maxHits;
    private int timesHit;
    private LevelManager levelManager;
    public Sprite[] spritesArray;
    public static int bricks  = 0;

    // Use this for initialization
    void Start() {

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();

    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //count how many times got hit
        timesHit++;
        if(timesHit == maxHits) { 
        Destroy(gameObject);
        }
        else
        {
            nextSprite();
        }
       

    }

    void nextSprite()
    {
        //if hit 1 time then we get sprite 1-1=0 index
        int spriteIndex = timesHit - 1;
        this.GetComponent<SpriteRenderer>().sprite = spritesArray[spriteIndex];
    }
    //TDOO remove when we actually win
    void YouWin()
    {

        levelManager.LoadNextLevel();
    }
}
