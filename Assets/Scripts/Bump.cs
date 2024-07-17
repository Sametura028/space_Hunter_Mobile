using System.Collections;
using System.Collections.Generic;
using Cinemachine;
// using UnityEditor.PackageManager.UI;
// using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bump : MonoBehaviour
{



    AudioSource aus;
    [SerializeField] float levelDelay = 0f;
    [SerializeField] AudioClip succes, death;
    [SerializeField] ParticleSystem succesParticle, deathParticle;
    bool isTransitionin = false, collisionDisabled = false;
    void Start()
    {
        aus = GetComponent<AudioSource>();


    }
    void Update()
    {
        nextlevevpres();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitionin || collisionDisabled) { return; }

        switch (other.gameObject.tag)
        {

            case "Fuel":
                break;
            case "Finish":

                levelComplated();
                break;
            case "Friendly":
                break;
            default:
                gameover();

                break;
        }
    }

    void nextlevevpres()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            NextSceneLoader();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Invoke("SceneReload", 0);
        }

    }


    void levelComplated()
    {
        Handheld.Vibrate();

        isTransitionin = true;
        GetComponent<Movement>().enabled = false;
        // GetComponent<AudioSource>().enabled = false;
        Invoke("NextSceneLoader", levelDelay);
        aus.PlayOneShot(succes);
        succesParticle.Play();
    }
    void gameover()
    {
        Handheld.Vibrate();
        deathParticle.Play();

        isTransitionin = true;
        GetComponent<Movement>().enabled = false;
        // GetComponent<AudioSource>().enabled = false;
        Invoke("SceneReload", levelDelay);
        aus.PlayOneShot(death);
    }
    void SceneReload()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);

    }
    void NextSceneLoader()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        currentScene++;
        if (currentScene == SceneManager.sceneCountInBuildSettings)
        {

            currentScene = 0;
        }
        SceneManager.LoadScene(currentScene);

    }
}
