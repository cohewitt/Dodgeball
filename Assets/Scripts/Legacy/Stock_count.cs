using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Stock_count : MonoBehaviour, IScore {
    private string player;
    private int score;
    private string stock;
    private Text output;
	// Use this for initialization
	void Start () {
        player = Helper.getPlayer(gameObject.name);
        score = 5;
        output = GetComponent<Text>();
	}
	public void addPoint()
    {
        score--;
        if (score <= 0)
        {
            GameObject.Find(player + " Player").GetComponent<PlayerMovement>().die();
            GameObject.Find("Score").GetComponent<scorekeeper>().endGame();
        }
    }
    public int getScore()
    {
        return score;
    }
	// Update is called once per frame
	void Update ()
    {
        output.text = player + " Stock: " + score;
	}
    string getPlayer()
    {
        return player;
    }
}
