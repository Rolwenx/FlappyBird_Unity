using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject PausePanel;
    private bool isPaused = false;

    void Start(){
        if (PausePanel != null)
        {
            PausePanel.SetActive(false);
        }
    }
    void Update()
    {

        if (ControlBird.instance._gamedOver) 
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.P) && ControlBird.instance._gameStarted)
        {
            if (isPaused)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }


}
