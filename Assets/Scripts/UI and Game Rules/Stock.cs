using UnityEngine;
using System.Collections.Generic;

public class Stock : MonoBehaviour, IgameType {
    private string gametype;
    public int startScore;
    private scorekeeper scoreBoard;
    // Use this for initialization
    void Start() {
        gametype = "stock";
        scoreBoard = GetComponent<scorekeeper>();
    }
    void Update()
    {
        checkScores();
    }

    public void incScore(ThrowObj input)
    {
        ScorePanel[] children = GetComponentsInChildren<ScorePanel>();
        GameObject hit = input.getHit();
        foreach (ScorePanel child in children)
        {
            if (Helper.getPlayer(child.name) == Helper.getPlayer(hit.name)) {
                child.subScore();
            }
        }
    }
    /// <summary>
    /// checks whether only one team is surviving
    /// </summary>
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
    public string getGameType()
    {
        return gametype;
    }
    public int getScore()
    {
        return startScore;
    }
    private void kill(string playerName)
    {
        GameObject.Find(playerName + " Player").GetComponent<PlayerMovement>().die();
    }
}
