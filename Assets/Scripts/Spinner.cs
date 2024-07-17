using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

    }

    [SerializeField] float xdeger = 0f, ydeger = 0f, zdeger = 0f;
    // Update is called once per frame
    void Update()
    {
        // float deger = ydeger * Time.deltaTime;
        transform.Rotate(xdeger, ydeger, zdeger);
    }
}
