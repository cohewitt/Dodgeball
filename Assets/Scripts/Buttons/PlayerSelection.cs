using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour {
    public static int playerCount = 2;
	// Use this for initialization
    void Update()
    {
        GameObject.Find("Player Count Text").GetComponent<Text>().text = "Player Count: " + playerCount;
    }
    public void twoPlayer()
    {
        playerCount = 2;
    }
    public void threePlayer()
    {
        playerCount = 3;
    }
    public void fourPlayer()
    {
        playerCount = 4;
    }
}
