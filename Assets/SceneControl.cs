using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    // this function will be called when the button is pressed in order to load the game scene. 

    public void LoadScreen(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
