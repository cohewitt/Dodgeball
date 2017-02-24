using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    public float time;
    private Text output;
    private int hour;
    private int second;
	// Use this for initialization
	void Start () {
        time = 30f * 1f;
        output = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (time > 0 || GetComponentInParent<scorekeeper>().getEnd())
        {
            time -= Time.deltaTime;
            hour = (int)time / 60;
            second = (int)time % 60;
            if (time < 0)
            {
                output.text = "Time: 0:00";
            }
            else if (second < 10)
            {
                output.text = "Time: " + hour + ":0" + second;
            }
            else
            {
                output.text = "Time: " + hour + ":" + second;
            }
        }
        else
        {
            output.text = "Time: 0:00";
            GetComponentInParent<scorekeeper>().endGame();
        }
	}
}
