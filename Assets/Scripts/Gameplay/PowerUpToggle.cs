using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpToggle : MonoBehaviour {
    public static bool toggle = false;
    private Text button;
	// Use this for initialization
	void Start () {
        button = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        button.text = "Power Ups:\r\n" + (toggle ? "On" : "Off");
	}
    public void onClick()
    {
        toggle = !toggle;
    }
}