using UnityEngine;
using System.Collections;

public class PlayerEnforcement : MonoBehaviour {
    private int playerCount = PlayerSelection.playerCount;
    private int teamCount;
    void Start()
    {
        teamCount = countTeams();
        setPlayers(playerCount,teamCount);
    }
    int countTeams()
    {
        int output = 0;
        string lastTeam = null;
        foreach(Transform player in GetComponentsInChildren<Transform>())
        {
            string teamName = Helper.getTeam(player.name);
            if (lastTeam == null||lastTeam != teamName)
            {
                lastTeam = teamName;
                output++;
            }
        }
        return output;
    }
    void setPlayers(int players,int teams)
    {
        string lastTeam = null;
        int teamPlayers = playerCount / teamCount;
        foreach (Transform player in GetComponentsInChildren<Transform>())
        {
            string teamName = Helper.getTeam(player.name);
            if (lastTeam == teamName)
            {
                if (teamPlayers<=0)
                {
                    Destroy(player.gameObject);
                }
                teamPlayers--;
            }
            else if (lastTeam == null)
            {
                lastTeam = teamName;
                teamPlayers--;
            }
            else
            {
                teamPlayers = playerCount / teamCount;
                lastTeam = teamName;
            }
        }
    }
}
