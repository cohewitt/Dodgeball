using UnityEngine;
using System.Collections;

public class hitCheck : MonoBehaviour {
    private IgameType rules;
    private GameObject self;
    public GameObject thrower;
    private PlayerMovement throwerScript;
    private Collider2D hitbox;
    private Collider2D ball;
    private bool held;
    public float throwPower;
    private string gameType;
    private ShotClock currentClock;
    // Use this for initialization
    void Start() {
        //setting my variables 
        self = gameObject.transform.parent.gameObject;
        hitbox = GetComponent<Collider2D>();
        ball = self.GetComponent<Collider2D>();
    }
    // Update is called before physics on an atomic clock
    void FixedUpdate()
    {
        if (held&&thrower)
        {
            self.GetComponent<Rigidbody2D>().MovePosition(thrower.transform.position + new Vector3(0, -.3f,0));
        }
    }
    //handle player picking up ball
    void pickup(GameObject player)
    {
        //Make the player the thrower
        thrower = player;
        //setup that player's shotclock
        try
        {
            currentClock = findClock(thrower.name);
            currentClock.startClock();
        }
        catch
        {
            Debug.LogError("Clock unreachable");
        }
        //Ignoring the player
        Physics2D.IgnoreCollision(ball, thrower.GetComponent<Collider2D>(), true);
        //undo all this on throw
        self.GetComponent<Rigidbody2D>().MovePosition(player.GetComponent<Rigidbody2D>().position);
        held = true;
        self.GetComponent<Rigidbody2D>().rotation = 0;
        self.GetComponent<Rigidbody2D>().freezeRotation = true;
    }
    //script to handle player contact
    public void throwBall()
    {
        if (held)
        {
            throwerScript = thrower.GetComponent<PlayerMovement>();
            Physics2D.IgnoreCollision(hitbox, thrower.GetComponent<Collider2D>(), true);
            held = false;
            self.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            self.GetComponent<Rigidbody2D>().AddForce(new Vector2(throwPower * (throwerScript.direction ? 1 : -1), 10f));
            self.GetComponent<Rigidbody2D>().freezeRotation = false;
        }
    }
    //handle player collisions
    void playerContact(GameObject player)
    {
        PlayerMovement playerScript = player.GetComponent<PlayerMovement>();
        //check to see if Ball is dead
        if (thrower == null)
        {
            //handle pickup case
            pickup(player.gameObject);
        }
        else
        {
            if (playerScript.getGrab() || Helper.getPlayer(player.name) == Helper.getPlayer(thrower.name))
            {
                pickup(player.gameObject);
            }
            //If the Player isn't Grabbing
            else
            {
                ThrowObj output = new ThrowObj(thrower, player);
                try
                {
                    GameObject.Find("Score").GetComponent<IgameType>().incScore(output);
                }
                catch
                {
                    Debug.LogError("scoreBoard Unreachable");
                }
            }
        }
    }
    //handles all collisions
    void OnTriggerEnter2D(Collider2D other)
    {
        //might be a better place for this block in throwBall
        if(other.tag == "line")
        {
            if(currentClock)clearClock();
            return;
        }
        GetComponent<AudioSource>().Play();
        //if the ball has been thrown
        if (thrower && !held) {
            //reenable collisions with the thrower
            enablePlayerCollisions(thrower);
        }
        //if the red player collides with the ball we need to handle all possibilities
        if (other.tag == "Player")
        {
            playerContact(other.gameObject);
        }
        else
        {
            thrower = null;
        }
    }
    //renables player collisions from whomever held the ball last
    void enablePlayerCollisions(GameObject player)
    {
        Collider2D playerHitbox = player.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(playerHitbox, hitbox, false);
        Physics2D.IgnoreCollision(playerHitbox, ball, false);
    }
    //If the shotclock causes the ball to reset it will use this to handle that
    public void reset(string team)
    {
        if (thrower)
        {
            enablePlayerCollisions(thrower);
            thrower = null;
        }
        held = false;
        self.transform.position = new Vector2((team == "Red" ? 3 : -3), 0);
        self.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
    ShotClock findClock(string playerName)
    {
        string team = findTeam(playerName);
        GameObject score = GameObject.Find(team + " Score");
        ShotClock output = score.GetComponent<ShotClock>();
        return output;
    }
    void clearClock()
    {
        currentClock.stopClock();
        currentClock = null;
    }
    void OnDestroy()
    {
        if (currentClock)
        {
            currentClock.stopClock();
        }
    }
    string findTeam(string playerName)
    {
        return Helper.getPlayer(playerName);
    }
    bool getHeld()
    {
        return held;
    }
}
