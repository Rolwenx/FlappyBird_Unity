using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void ReplayGameMatch(){

        ControlBird.instance.ReplayGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
