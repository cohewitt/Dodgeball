using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {
    private Scene UI;
    private Scene Board;
    void Start()
    {
        try
        {
            UI = GameObject.Find("Score").scene;
        }
        catch
        {
            Debug.LogError("UI not loaded");
        }
        try
        {
            Board = GameObject.Find("Players").scene;
        }
        catch
        {
            Debug.LogError("GameBoard not loaded");
        }
    }
    public void onClick()
    {
        SceneManager.LoadScene(UI.name);
        SceneManager.LoadScene(Board.name,LoadSceneMode.Additive);
        SceneManager.LoadScene(gameObject.scene.name,LoadSceneMode.Additive);
    }
}
