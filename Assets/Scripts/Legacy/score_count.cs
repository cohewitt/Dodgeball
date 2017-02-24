using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score_count : MonoBehaviour, IScore {
    private string player;
    private int score;
    private Text output;
    private Helper help;
	// Use this for initialization
	void Start () {
        player = Helper.getPlayer(player);
        score = 0;
        output = GetComponent<Text>();
	}
	
    void Update()
    {
        output.text = player + " score: " + score;
    }
    public int getScore()
    {
        return score;
    }
	public void addPoint()
    {
        score++;
    }
    string getPlayer()
    {
        return player;
    }
}
