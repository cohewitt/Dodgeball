using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Stock_Button : MonoBehaviour {
    public void onClick()
    {
        SceneManager.LoadScene("Game Board");
        SceneManager.LoadScene("Stock UI", LoadSceneMode.Additive);
        SceneManager.LoadScene("Pause Menu", LoadSceneMode.Additive);
        if (PowerUpToggle.toggle)   
        {
            SceneManager.LoadScene("DoubleJump", LoadSceneMode.Additive);
        }
    }
}
