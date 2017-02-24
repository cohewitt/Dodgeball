using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Score_Attack_Button : MonoBehaviour
{

    public void onClick()
    {
        SceneManager.LoadScene("Game Board");
        SceneManager.LoadScene("Score UI", LoadSceneMode.Additive);
        SceneManager.LoadScene("Pause Menu", LoadSceneMode.Additive);
        if (PowerUpToggle.toggle)
        {
            SceneManager.LoadScene("DoubleJump", LoadSceneMode.Additive);
        }
    }
}