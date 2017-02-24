using UnityEngine;
using System.Collections;

public class teamScoreCount{
    public int score;
    public string team;
    public teamScoreCount(int inScore,string inTeam)
    {
        score = inScore;
        team = inTeam;
    }
    public int getScore()
    {
        return score;
    }
    public string getTeam()
    {
        return team;
    }
    public void addScore(int inScore)
    {
        score += inScore;
    }
}
