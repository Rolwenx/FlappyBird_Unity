using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlBird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody; 
    [SerializeField] private float _speed = 5f; 
    [SerializeField] GameObject _gameOverIcon;
    private bool _GamePaused = false; 

    // Start is called before the first frame update
    void Start()
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.CompareTag("Ground")){

            _gameOverIcon.SetActive(true);
            // on fais stop time koua
            Time.timeScale = 0;
            _GamePaused = true;
        }
    }

    public void ReplayGame()
        {

            if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
            
        }

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

        if (_GamePaused && Input.GetKeyDown(KeyCode.Space))
            {

                ReplayGame();
            }

    }
}

