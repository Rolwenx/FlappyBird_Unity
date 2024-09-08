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

    public static ControlBird instance;

    public GameObject collision_music;

    [SerializeField] private RuntimeAnimatorController[] birdAnimations; // Different animation controllers for each color
    [SerializeField] private Animator birdAnimator;

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
        int selectedColorIndex = PlayerPrefs.GetInt("BirdColor", 0);

        birdAnimator.runtimeAnimatorController = birdAnimations[selectedColorIndex];
        Time.timeScale = 1;
    }

    private void GameOver(){
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        _currentScoreText.gameObject.SetActive(false);
        _bestScoreText.gameObject.SetActive(false);

        _gameOverCurrentScoreText.text = "Score:\n" + ScoreManager.instance.GetCurrentScore().ToString();
        _gameOverBestScoreText.text = "Best Score:\n" + ScoreManager.instance.GetBestScore().ToString();

    }
    private void OnCollisionEnter2D(Collision2D collision){


        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Pipe")){
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

        // GetKey is for continuous press, GetKeyDown is for the first press, 
        // GetKeyUp is for release

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = Vector2.zero; 
            _rigidbody.AddForce(new Vector2(0f, _speed), ForceMode2D.Impulse); 
        }

        Debug.Log(ScoreManager.instance.GetCurrentScore());

    }
}

