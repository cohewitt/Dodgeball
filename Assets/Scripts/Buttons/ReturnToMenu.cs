using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour {
    public void onClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
