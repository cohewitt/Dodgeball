using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Single_Elimination_Button : MonoBehaviour
{
    public void onClick()
    {
        SceneManager.LoadScene("Game Board");
        SceneManager.LoadScene("Single Elimination UI",LoadSceneMode.Additive);
        SceneManager.LoadScene("Pause Menu",LoadSceneMode.Additive);
        if (PowerUpToggle.toggle)
        {
            SceneManager.LoadScene("DoubleJump", LoadSceneMode.Additive);
        }
    }
}
