using UnityEngine;
using System.Collections;

public class DoubleJump : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("doubleJumpTriggered");
            other.GetComponent<PlayerMovement>().powerUp();
            GetComponentInParent<PowerUpAnimation>().usePowerUp();
        }
    }
}
