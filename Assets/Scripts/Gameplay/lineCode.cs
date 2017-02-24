using UnityEngine;
using System.Collections;

public class lineCode : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //ignore collision with ball
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("Ball").GetComponent<CircleCollider2D>());
        //Need this collision for shot clock
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("hit mask").GetComponent<CircleCollider2D>());
    }
}
