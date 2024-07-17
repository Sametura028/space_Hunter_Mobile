using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }    Rigidbody rb;


    // Update is called once per frame
    void Update()
    {
              
    }
    private void OnCollisionEnter(Collision other)
    {
      rb = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;

    }
}
