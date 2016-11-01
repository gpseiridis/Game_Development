using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {

    private int maxHits;
    private int timesHit;
    private LevelManager levelManager;
    private bool Breakable;
    private int chanceToInvoke = 2;

    public Powerup powerup;

    public Sprite[] spritesArray;
    public static int bricks  = 0;
    private Powerup[] powerups;
    private Powerup[] powerupClones;

    // Use this for initialization
    void Start() {
        powerups = GameObject.FindObjectsOfType<Powerup>();
        

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
        powerups = GameObject.FindObjectsOfType<Powerup>();
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
            instantiatePowerUp();
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

    void instantiatePowerUp()
    {
        //powerup will instantiate if based on a given probability and only if there is no other powerup around
        if(Random.Range(0, chanceToInvoke) == 0 && powerups.Length<1)
        {
            
            Debug.Log("Lets create a powerup!");
       //  Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //Instantiate(powerup, pos, Quaternion.identity);      

      Instantiate(powerup, transform.position, transform.rotation);
     

       }
    }

    
}
