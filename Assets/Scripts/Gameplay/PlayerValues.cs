using UnityEngine;
using System.Collections;

public class PlayerValues : MonoBehaviour {
    public float moveSpeed;
    public float jumpPower;
    private bool canMove;
	// Use this for initialization
	void Start ()
    {
        canMove = true;
	}
    public bool MoveCheck()
    {
        return canMove;
    }
    public void cycleMove()
    {
        canMove = !canMove;
    }
    public float getSpeed()
    {
        return moveSpeed;
    }
    public float getJump()
    {
        return jumpPower;
    }
}
