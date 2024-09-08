using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerColorSelection : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController[] birdAnimations;

    public void SelectBirdColor(int colorIndex)
    {
        PlayerPrefs.SetInt("BirdColor", colorIndex);
        PlayerPrefs.Save();

        SceneManager.LoadScene(1);
    }
}
