using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SecretButton: MonoBehaviour{
    public void onClick()
    {
        PlayerSelection.playerCount = 2;
        SceneManager.LoadScene("Secret Level");
        SceneManager.LoadScene("Score UI",LoadSceneMode.Additive);
        SceneManager.LoadScene("pause Menu", LoadSceneMode.Additive);

    }
}
