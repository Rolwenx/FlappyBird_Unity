using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipe;
    [SerializeField] private float _initialSpawnTime = 2f; 
    // As the game progress,  the spawn time will be reduced so it's good
    [SerializeField] private float _spawnTimeDecrease = 0.01f;
    [SerializeField] private float _minSpawnTime = 0.5f; 
    [SerializeField] private float _initialHeightRange = 2f;  
     // Same as before, the height range will be decreased as the game progress
    [SerializeField] private float _heightRangeDecrease = 0.01f; 
    [SerializeField] private float _minHeightRange = 1f; 
    [SerializeField] private float _minPipeSpacing = 3f; 
    [SerializeField] private float _maxPipeSpacing = 5f; 

    private float _timer;
    private float _spawnTime;
    private float _heightRange;


    private void Start(){
        _spawnTime = _initialSpawnTime;
        _heightRange = _initialHeightRange;
        _timer = 0;
        SpawnPipe();
    }

    private void Update(){
        _timer += Time.deltaTime;

        if (_timer > _spawnTime)
        {
            SpawnPipe();
            _timer = 0;

            if (_spawnTime > _minSpawnTime)
            {
                _spawnTime -= _spawnTimeDecrease;
            }

            if (_heightRange > _minHeightRange)
            {
                _heightRange -= _heightRangeDecrease;
            }
        }
    }

    private void SpawnPipe(){

        float pipeSpacing = Random.Range(_minPipeSpacing, _maxPipeSpacing);

        float gapHeight = Random.Range(-_heightRange, _heightRange); 

        Vector3 spawnPosition = transform.position + new Vector3(pipeSpacing, gapHeight);
        GameObject pipe = Instantiate(_pipe, spawnPosition, Quaternion.identity);
        Destroy(pipe, 20f);
    
    }

}
