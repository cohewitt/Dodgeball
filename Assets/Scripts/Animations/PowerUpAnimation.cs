using UnityEngine;
using System.Collections;

public class PowerUpAnimation : MonoBehaviour {
    private Rigidbody2D self;
    public float respawn;
	// Use this for initialization
	void Start () {
        respawn = 5;
        self = GetComponent<Rigidbody2D>();
        self.velocity = (new Vector2(5, 0));
	}
	
	// Update is called once per frame
	void Update () {
        if(!transform.GetChild(0).gameObject.activeSelf)
        {
            respawn -= Time.deltaTime;
            if (respawn <= 0)
            {
                respawn = 5;
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
	    if (transform.localPosition.x > 5)
        {
            self.velocity = (new Vector2(-5, 0));
        }
        else if(transform.localPosition.x < -5)
        {
            self.velocity = (new Vector2(5, 0));
        }
	}
    public void usePowerUp()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
