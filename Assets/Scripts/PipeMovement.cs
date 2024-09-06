using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f; 

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -20f)
        {
            Destroy(gameObject); 
        }
    }
}
