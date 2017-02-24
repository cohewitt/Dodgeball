using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Credits_Button : MonoBehaviour {
public void onClick()
    {
        SceneManager.LoadScene("Credits");
    }
}
