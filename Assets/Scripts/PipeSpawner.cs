using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _pipe;
    private float _spawnInterval = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(_pipe, transform.position, transform.rotation);
    }
}
