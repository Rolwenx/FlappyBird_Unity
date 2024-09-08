using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncrease : MonoBehaviour
{
    
    public GameObject gainPoint_music;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            ScoreManager.instance.PlayerScores();
        }

         // we create the object of collision music
        GameObject GainPointMusicObject = Instantiate(gainPoint_music, transform.position, transform.rotation);
        AudioSource GainPointMusicAudioSource = GainPointMusicObject.GetComponent<AudioSource>();

    }
}
