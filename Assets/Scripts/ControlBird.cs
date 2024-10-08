using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlBird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody; 
    [SerializeField] private float _speed = 5f; 
    [SerializeField] GameObject _gameOverPanel;

    [SerializeField] private TextMeshProUGUI _currentScoreText;  
    [SerializeField] private TextMeshProUGUI _bestScoreText; 
    [SerializeField] private TextMeshProUGUI _gameOverCurrentScoreText; 
    [SerializeField] private TextMeshProUGUI _gameOverBestScoreText; 
    [SerializeField] private GameObject _startGamePanel;

    public static ControlBird instance;

    public GameObject collision_music;

    [SerializeField] private RuntimeAnimatorController[] birdAnimations;
    [SerializeField] private Animator birdAnimator;

    public bool _gameStarted = false;
    public bool _gamedOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
 
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        _gameOverPanel.SetActive(false);
        _startGamePanel.SetActive(true);
        Time.timeScale = 0; 
        int selectedColorIndex = PlayerPrefs.GetInt("BirdColor", 0);

        birdAnimator.runtimeAnimatorController = birdAnimations[selectedColorIndex];
    }


    private void GameOver(){
        _gameOverPanel.SetActive(true);
        _gamedOver = true;
        Time.timeScale = 0;
        _currentScoreText.gameObject.SetActive(false);
        _bestScoreText.gameObject.SetActive(false);

        _gameOverCurrentScoreText.text = "Score:\n" + ScoreManager.instance.GetCurrentScore().ToString();
        _gameOverBestScoreText.text = "Best Score:\n" + ScoreManager.instance.GetBestScore().ToString();

    }
    private void OnCollisionEnter2D(Collision2D collision){


        Debug.Log("Collision Detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Pipe"))
        {
            GameOver();
        }

        // we create the object of collision music
        GameObject CollisionMusicObject = Instantiate(collision_music, transform.position, transform.rotation);
        AudioSource CollisionMusicAudioSource = CollisionMusicObject.GetComponent<AudioSource>();

        Destroy(CollisionMusicObject, CollisionMusicAudioSource.clip.length);

    }
    public void ReplayGame(){
        ScoreManager.instance.ResetScore();
         ScoreManager.instance.UpdateBestScore();
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        _currentScoreText.gameObject.SetActive(true);
        _bestScoreText.gameObject.SetActive(true);
        _gameOverPanel.SetActive(false);
            
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

        if (_gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.velocity = Vector2.zero; 
                _rigidbody.AddForce(new Vector2(0f, _speed), ForceMode2D.Impulse); 
            }
        }

    }

    private void StartGame()
    {
        _startGamePanel.SetActive(false);
        Time.timeScale = 1; 
        _gameStarted = true;
    }

}

