using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {

    private int maxHits;
    private int timesHit;
    private LevelManager levelManager;
    private bool Breakable;

    public Sprite[] spritesArray;
    public static int bricks  = 0;

    // Use this for initialization
    void Start() {
        //will be true if the current brick has a Tag of breakable
        Breakable = (this.tag == "Breakable");
        if (Breakable)
        {
            bricks++;
        }

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();

    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (Breakable) { 
            HitHandler();
        }

        
       

    }


    void HitHandler()
    {
        //count how many times got hit
        timesHit++;
        maxHits = spritesArray.Length + 1;
        if (timesHit == maxHits)
        {
            bricks--;
            //BrickDestroyed is called everytime we actually destroyed a brick.
            levelManager.BrickDestroyed();
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
        //prevent the disappearance of a sprite in case we forget to put a sprite for it
        if (spritesArray[spriteIndex]) { 
        this.GetComponent<SpriteRenderer>().sprite = spritesArray[spriteIndex];
        }
    }
    //TDOO remove when we actually win
    void YouWin() 
    {

        levelManager.LoadNextLevel();
    }
}
