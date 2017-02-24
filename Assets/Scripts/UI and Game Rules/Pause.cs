using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    private bool isPaused;
    private PlayerValues players;
	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;
        players = GameObject.Find("Players").GetComponent<PlayerValues>();
        isPaused = false;
        toggleChildren();
    }
    public void CyclePause()
    {
        isPaused = !isPaused;
        players.cycleMove();
        toggleChildren();
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("menuPause"))
        {
            CyclePause();
        }
	}
    void toggleChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(!transform.GetChild(i).gameObject.activeSelf);
        }
    } 
}
