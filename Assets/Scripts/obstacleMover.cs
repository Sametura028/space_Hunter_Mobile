using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class obstacleMover : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startPos;
    [SerializeField] Vector3 movementVector;
    // [SerializeField]
    [Range(0, 1)] float movementValue;
    [SerializeField] float period = 2f;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float sinWave = MathF.Sin(cycles * tau);

        movementValue = (sinWave + 1f) / 2f;

        Vector3 offset = movementVector * movementValue;
        transform.position = startPos + offset;

    }
}



