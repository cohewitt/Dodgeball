using UnityEngine;
using System.Collections;

public class ScoreAttack : MonoBehaviour, IgameType {
    private string gameType;
    private int score = 0;
	// Use this for initialization
	void Start () {
        gameType = "Score";
	}
    public string getGameType()
    {
        return gameType;
    }
    public void incScore(ThrowObj thrown)
    {
        ScorePanel[] children = GetComponentsInChildren<ScorePanel>();
        foreach(ScorePanel child in children)
        {
            if (child.getPlayer() == Helper.getPlayer(thrown.getThrower().name))
            {
                child.addScore();
            }
        }
    }
    public int getScore()
    {
        return score;
    }

}
