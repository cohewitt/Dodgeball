using UnityEngine;
using System.Collections;

public class SingleElimination : MonoBehaviour,IgameType {
    private string gameType;
    private int score = 1;
    scorekeeper scoreBoard;
	// Use this for initialization
	void Start () {
        gameType = "SingleElimination";
        scoreBoard = GetComponentInParent<scorekeeper>();
	}
    void Update()
    {
        checkScores();
    }

    public string getGameType()
    {
        return "lives";
    }
    public void incScore(ThrowObj thrown)
    {
        ScorePanel[] children = GetComponentsInChildren<ScorePanel>();
        GameObject player = thrown.getHit();
        foreach(ScorePanel child in children)
        {
            if (child.getPlayer() == Helper.getPlayer(player.name))
            {
                child.subScore();
            }
        }
    }
    void checkScores()
    {
        ScorePanel[] children = GetComponentsInChildren<ScorePanel>();
        string lastTeam = null;
        foreach (ScorePanel child in children)
        {
            if (child.isDead()) continue;
            if (child.getScore() <= 0)
            {
                GameObject.Find(child.getPlayer() + " Player").GetComponent<PlayerMovement>().die();
                child.die();
            }
        }
        foreach (ScorePanel child in children)
        {
            if (child.isDead())
            {
                continue;
            }
            string team = Helper.getTeam(child.name);
            if (lastTeam == null)
            {
                lastTeam = team;
            }
            if (team != lastTeam)
            {
                return;
            }
            lastTeam = team;
        }
        scoreBoard.endGame(lastTeam);
    }
    public int getScore()
    {
        return score;
    }


}
