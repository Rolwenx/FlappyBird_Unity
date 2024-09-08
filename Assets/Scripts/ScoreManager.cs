using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _BestScoreText;
    private int _currentScore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentScoreText.text = _currentScore.ToString();
        _BestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        ResetScore();
        UpdateBestScore();
    }

    public void PlayerScores()
    {
        _currentScore++;
        _currentScoreText.text = _currentScore.ToString(); 
        UpdateBestScore();
    }


    // Update is called once per frame
    public void UpdateBestScore()
    {
        int highestScore = PlayerPrefs.GetInt("HighScore", 0); 
        if (_currentScore > highestScore)
        {
            PlayerPrefs.SetInt("HighScore", _currentScore); 
            _BestScoreText.text = "Best Score: " + _currentScore.ToString();
        }
    }

    public void ResetScore()
    {
        _currentScore = 0;
        _currentScoreText.text = _currentScore.ToString();
    }

    public int GetCurrentScore()
    {
        return _currentScore;
    }

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
}
