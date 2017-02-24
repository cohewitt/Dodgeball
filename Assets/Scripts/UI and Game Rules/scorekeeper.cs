using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scorekeeper : MonoBehaviour {
    public Text winText;
    public float MenuReturn;
    private bool gameEnd;
    private string winner;
    // Use this for initialization
    void Start()
    {
        MenuReturn = 5f;
        winText = GameObject.Find("Win Text").GetComponent<Text>();
    }

    /// <summary>
    /// Handles the case when you wish to declare a winner outside of the endGame value.
    /// </summary>
    /// <param name="team"></param>
    public void endGame(string team)
    {
        Destroy(GameObject.Find("hit mask"));
        winText.text = team + " Wins!";
        GameObject.Find("Players").GetComponent<PlayerValues>().cycleMove();
        gameEnd = true;
    }

    /// <summary>
    /// Handles ending the game and declaring a winner
    /// </summary>
    public void endGame()
    {
        ScorePanel[] Panels = GetComponentsInChildren<ScorePanel>();
        Destroy(GameObject.Find("hit mask"));
        List<teamScoreCount> teamScores = new List<teamScoreCount>();
        foreach (ScorePanel panel in Panels)
        {
            string newTeam = Helper.getTeam(panel.name);
            bool added = false;
            foreach (teamScoreCount score in teamScores)
            {
                if (score.getTeam() == newTeam)
                {
                    score.addScore(panel.getScore());
                    added = true;
                    continue;
                }
            }
            if (added) continue;
            teamScores.Add(new teamScoreCount(panel.getScore(), newTeam));
        }
        teamScoreCount highestScore = null;
        bool tie = false;
        foreach (teamScoreCount score in teamScores)
        {
            if(highestScore == null)
            {
                highestScore = score;
                }
                else if (score.getScore() > highestScore.getScore())
                {
                tie = false;
                highestScore = score;
                }
                else if (score.getScore() == highestScore.getScore())
                {
                    tie = true;
                }
            }
            if (tie == true)
            {
                winText.text = "It's a draw!";
                return;
            }
            else
            {
                 winText.text = Helper.getTeam(highestScore.getTeam()) + " wins!";
            }
        GameObject.Find("Players").GetComponent<PlayerValues>().cycleMove();
        gameEnd = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            endGame();
        }
        if (getEnd())
        {
            MenuReturn -= Time.deltaTime;
            if (MenuReturn <= 0)
            {
                SceneManager.LoadScene("menu");
            }
        }
    }


    public bool getEnd()
    {
        return gameEnd;
    }
}
