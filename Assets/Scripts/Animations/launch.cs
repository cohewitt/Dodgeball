using UnityEngine;
using System.Collections;

public class launch : MonoBehaviour {
    public GameObject Banner;
    public GameObject Buttons;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        Banner = GameObject.Find("Banner");
        Banner.transform.localPosition = new Vector2(0, -430f);
        Banner.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 150f);

        Buttons = GameObject.Find("Buttons");
        Buttons.transform.localScale = new Vector2(.25f, .25f);
        Buttons.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
        if (Input.anyKey)
        {
            Banner.transform.localPosition = new Vector2(0f, 130f);
            Banner.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Buttons.transform.localScale = new Vector3(1, 1, 1);
        }
        if(Banner.transform.localPosition.y >= 130f)
        {
            Banner.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Banner.transform.localPosition = new Vector3(0, 130, 1);
            Buttons.SetActive(true);
            //if the buttons are zoomed all the way in
            if (Buttons.transform.localScale.x < 1)
            {
                float newScale = Buttons.transform.localScale.x + .01f;
                Buttons.transform.localScale = new Vector3(newScale, newScale, 1f);
            }
            else
            {
                Buttons.transform.localScale = new Vector3(1, 1, 1);
            }
        }
	}
}
