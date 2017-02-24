using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {
    //player's speed inherited from the players object
    private float speed;
    //jump power inherited from the players object
    private float jumpPower;
    //Horizontal movement
    private float h;
    //physics body
    private Rigidbody2D myRig;
    //boolean on whether or not the player is jumping used to get jumping feel "right".
    private bool isJumping;
    //color of player
    private string player;
    //whether it's facing right
    public bool direction;
    //boolean to keep track of the player's grab status
    private bool grab;
    //timer for grabs
    private float grabTimer;
    //direction used for the last movement input
    private bool oldDirection;
    //pointer to the ball's controlling script
    private hitCheck ball;
    //reference to the animator to set it's parameter's
    private Animator animator;
    //pointer to the parent's master values
    private PlayerValues masterValues;
    //whether or not the player is alive
    private bool Alive;
    //if the player can move.
    private bool canMove;
    //whether or not you can double jump
    private bool doubleJump;
    //the charge of double jump
    private bool doubleJumpCharge;

    //initialization
    void Start()
    {
        player = Helper.getPlayer(gameObject.name);
        Alive = true;
        masterValues = GetComponentInParent<PlayerValues>();
        speed = masterValues.getSpeed();
        jumpPower = masterValues.getJump();
        canMove = masterValues.MoveCheck();
        ball = GameObject.Find("hit mask").GetComponent<hitCheck>();
        myRig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        grab = false;
        bool isRight = 0 < GetComponent<Transform>().localScale.x;
        oldDirection = isRight;
        direction = isRight;
    }

    //handles flipping the transform of the player when it turns around
    void Flip()
    {
        // Switch the way the player is labelled as facing
        oldDirection = !oldDirection;

        // Multiply the player's x local scale by -1
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //updates every physics calculation
    void Update()
    {
        //if you're alive check whether players can move
        if (Alive) canMove = masterValues.MoveCheck();
        if (canMove) {
            //get the last direction used
            h = Input.GetAxisRaw(player + "Horizontal");
            direction = (h != 0 ? h > 0 : direction);
            updateanimator(myRig.velocity);
            if (direction != oldDirection) {
                Flip();
            }
            if (Input.GetButtonDown(player + "Jump") )
            {
                if (Mathf.Abs(myRig.velocity.y) == 0)
                {
                    //If we pressed the jump button and are not moving on the Y velocity...
                    isJumping = true;
                }
                else if (doubleJump && doubleJumpCharge)
                {
                    isJumping = true;
                    doubleJumpCharge = false;
                }
            }
            if (Input.GetButtonDown(player + "Throw"))
            {
                if(ball.thrower == gameObject)
                {
                    animator.SetTrigger("Throw");
                    ball.throwBall();
                }
  
            }

            //if we're grabbing...
            if (grab)
            {
                //make sure grab is declinated
                grabTimer -= Time.deltaTime;
                //if we end up with grab removed grab is false
                if (grabTimer < 0f) grab = false;
            }
            //handles the "Grab" input
            if (Input.GetButtonDown(player + "Catch"))
            {
                //if we're not already grabbing
                if (!grab && !(ball.thrower == gameObject))
                {
                    //trigger grab animation
                    animator.SetTrigger("Catch");
                    //set grab and the grab timer
                    grab = true;
                    grabTimer = .05f;
                }
            }
        }

    }

    //handles updating the sanimator
    private void updateanimator(Vector2 velocity)
    {
        animator.SetInteger("X", (int)velocity.x);
        animator.SetInteger("Y", (int)velocity.y);
        animator.SetBool("Right", direction);
    }

    //update before the physics animations
    void FixedUpdate()
    {
        
        if (Alive && canMove)
        {
            //handles moving left and right
            myRig.velocity = new Vector2(h * speed * Time.deltaTime, myRig.velocity.y);
            //handles jumping
            if (isJumping)
            {
                GetComponent<AudioSource>().Play();
                isJumping = false;
                myRig.velocity = new Vector2(myRig.velocity.x, jumpPower);
            }
        }
    }

    //handles if the ball reports he is hit
    public void powerUp()
    {
        doubleJump = true;
        doubleJumpCharge = true;
    }

    //kills the player
    public void die()
    {
        Alive = false;
        canMove = false;
        myRig.AddForce(new Vector2((direction?-500f:500f),20));
        animator.SetTrigger("Dead");
    }

    //getter for player
    public string getPlayer()
    {
        return player;
    }
    
    //used to check for double Jumps
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Platform")
        {
            doubleJumpCharge = true;
        }
    }
    //returns grab's current value
    public bool getGrab()
    {
        return grab;
    }
}
