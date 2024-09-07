using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipePairPrefab;  // Reference to the pipe pair prefab (parent GameObject containing both pipes)
    [SerializeField] private float _spawnInterval = 2f;   // Time between spawns
    [SerializeField] private float _gapSize = 4f;         // Gap size between the top and bottom pipes
    [SerializeField] private float _maxYOffset = 2f;      // Maximum offset for vertical movement of the pipe pair to make the game dynamic
    private float _timer = 0;

    void Start()
    {
        SpawnPipePair();  // Spawn the first pair immediately
    }

    void Update()
    {
        if (_timer < _spawnInterval)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            SpawnPipePair();  // Spawn pipe pairs at regular intervals
            _timer = 0;
        }
    }

    // Method to spawn a pair of pipes with a randomized vertical offset
    void SpawnPipePair()
    {
        // Randomize the vertical offset for the pipe pair within the given bounds (_maxYOffset)
        float yOffset = Random.Range(-_maxYOffset, _maxYOffset);

        // Position for the pipe pair, with the Y-offset applied
        Vector3 spawnPosition = new Vector3(transform.position.x, yOffset, 0);

        // Instantiate the pipe pair prefab with the correct position
        GameObject pipePair = Instantiate(_pipePairPrefab, spawnPosition, Quaternion.identity);

        // Adjust the top and bottom pipes within the pipe pair prefab to have the specified gap
        Transform topPipe = pipePair.transform.Find("TopPipe");  // Find the top pipe in the prefab
        Transform bottomPipe = pipePair.transform.Find("BottomPipe");  // Find the bottom pipe in the prefab

        if (topPipe != null && bottomPipe != null)
        {
            // Position the top pipe above the gap
            topPipe.transform.localPosition = new Vector3(0, _gapSize / 2, 0);

            // Position the bottom pipe below the gap
            bottomPipe.transform.localPosition = new Vector3(0, -_gapSize / 2, 0);
        }
    }
}
