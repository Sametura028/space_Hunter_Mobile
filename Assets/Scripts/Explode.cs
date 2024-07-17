using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    // Start is called before the first frame update
      [SerializeField] ParticleSystem succesParticle, deathParticle;
    bool isTransitionin = false, collisionDisabled = false;
    void Start()
    {


    }
    void Update()
    {
        // nextlevevpres();
         deathParticle.Play();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitionin || collisionDisabled) { return; }

        switch (other.gameObject.tag)
        {

            case "Fuel":
                break;
            case "Finish":

                deathParticle.Play();

                break;
            case "Friendly":
              deathParticle.Play();
   break;
            default:
 deathParticle.Play();

                break;
        }
    }





}
