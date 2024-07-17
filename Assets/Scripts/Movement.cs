using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    AudioSource aus;
    [SerializeField] float flightSpeed = 8f, rotationSpeed = 8;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem boost, leftboost, rightboost;

    void Awake()
    {
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aus = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessInput();
        ProcessRotation();
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    void ProcessInput()
    {
        if (Keyboard.current.spaceKey.isPressed || Keyboard.current.wKey.isPressed)
        {
        // Handheld.Vibrate();

            rb.AddRelativeForce(Vector3.up * flightSpeed * Time.deltaTime);

            if (!aus.isPlaying)
            {
                aus.PlayOneShot(mainEngine);
            }
            if (!boost.isPlaying)
            {
                boost.Play();
            }
        }
        else
        {
            boost.Stop();
            aus.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            DirectionOfRotation(rotationSpeed);
            rightboost.Play();
        // Handheld.Vibrate();

            if (Keyboard.current.spaceKey.isPressed || Keyboard.current.wKey.isPressed)
            {
                boost.Play();
            }
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            leftboost.Play();
        // Handheld.Vibrate();

            if (Keyboard.current.spaceKey.isPressed || Keyboard.current.wKey.isPressed)
            {
                boost.Play();
            }
            DirectionOfRotation(-rotationSpeed);
        }
    }

    void DirectionOfRotation(float direction)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.left * direction * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
