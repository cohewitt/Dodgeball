using UnityEngine;
using System.Collections;

public class TextCrawl : MonoBehaviour {
    private Rigidbody text;
    public float crawl;
	// Use this for initialization
	void Start () {
        text = GetComponent<Rigidbody>();
        text.AddRelativeForce(new Vector3(0f, crawl,0f));
	}
    void Update()
    {
        if (transform.localPosition.y > 379)
        {
            GetComponent<AudioSource>().Stop();
            transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
