using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour {
    private IgameType gameType;
    private string player;
    private string team;
    public int score;
    private string output;
    private ShotClock clock;
    private Text display;
    private bool dead;
    //called at intialization of object
	void Start () {
        dead = false;
        gameType = GetComponentInParent<IgameType>();
        player = Helper.getPlayer(transform.name);
        team = Helper.getTeam(transform.name);
        score = gameType.getScore();
        clock = GetComponentInChildren<ShotClock>();
        display = GetComponentInChildren<Text>();
        checkPlayer();
	}
	
	// Update is called once per frame
	void Update () {
        checkPlayer();
        display.text = player + " " + gameType.getGameType() + ": " + score;
	}

    public void subScore()
    {
        if (!isDead()){
            score--;
        }
    }

    public void addScore()
    {
        if (!isDead())
        {
            score++;
        }
    }

    public int getScore()
    {
        return score;
    }

    public void die()
    {
        dead = true;
    }

    public bool isDead()
    {
        return dead;
    }

    public string getTeam()
    {
        return team;
    }
    public string getPlayer()
    {
        return player;
    }
    public void checkPlayer()
    {
        if (!GameObject.Find(player + " Player"))
        {
            Destroy(gameObject);
        }
    }
}
