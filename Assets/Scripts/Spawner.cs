using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
       
    public GameObject metor;
    // Start is called before the first frame update
    void Start()
    {
         InvokeRepeating("SpawnMeteor", 0f, .2f);
    }

    // Update is called once per frame
    void SpawnMeteor()
    {
        // Vector3 randomSpawnPosition = new Vector3(Random.Range(-10,11), 50, Random. Range(-10, 11));
        //   Instantiate(metor, randomSpawnPosition, Quaternion.identity ) ;
          Vector3 randomSpawnPosition = new Vector3(Random.Range(-50, 25), 50,Random.Range(-2,-3) );
        Instantiate(metor, randomSpawnPosition, Quaternion.identity);
    }
}

   
