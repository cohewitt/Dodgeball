using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShotClock : MonoBehaviour {
    private float time;
    private string team;
    private hitCheck ball;
    private GameObject clock;
    private bool isTicking;
	// Use this for initialization
	void Start () {
        isTicking = false;
        time = 9.9f;
        team = gameObject.name.Substring(0,3);
        ball = GameObject.Find("hit mask").GetComponent<hitCheck>();
        clock = transform.FindChild("Shot Clock").gameObject;
        clock.SetActive(false);
	}

    // Update is called once per frame
    void Update() {
        if (isTicking)
        {
            clock.SetActive(true);
            time -= Time.deltaTime;
            float output = Mathf.Round(time * 10) / 10;
            clock.GetComponent<Text>().text = "Shot Clock: "+ output + (output % 1f == 0f ?".0":"");
        }
        else
        {
            clock.SetActive(false);
            time = 9.9f;
        }
        if (time <= 0f)
        {
            ball.reset(team);
            stopClock();
            clock.SetActive(false);
            time = 9.9f;
        }
	}
    public void startClock()
    {
        isTicking = true;
    }
    public void stopClock()
    {
        isTicking = false;
    }
}
