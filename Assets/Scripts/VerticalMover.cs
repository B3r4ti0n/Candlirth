using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMover : MonoBehaviour
{
    public float amplitude = 2f;
    public float speed = 2f;
    
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(startPosition.x, startPosition.y + offset, startPosition.z);
    }
}
