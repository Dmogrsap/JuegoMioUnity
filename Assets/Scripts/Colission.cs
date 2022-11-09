using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colission : MonoBehaviour
{
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    [SerializeField] float delayLoad;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;

    bool isTransitioning = false;
    bool disableColission = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || disableColission) { return; }

        switch (other.gameObject.tag)
        {
            case "Finish":
                FinishSequence();
                break;
            case "Hit":
                CrashSequence();
                break;
        }
    }

    void CrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        GetComponent<Movements>().enabled = false;
        Invoke("ReloadLevel", delayLoad);
    }

    void FinishSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Movements>().enabled = false;
        Invoke("NextLevel",delayLoad); 
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1 ;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
       SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    // bool transicion = false;
    // bool quitarColicion = false;

    // void Start()
    // {
    //     audioSource = GetComponent<AudioSource>();
    // }

    // void Update()
    // {
    //     RespondToDebugKeys();
    // }

    // void RespondToDebugKeys()
    // {
    //     if(Input.GetKeyDown(KeyCode.L))
    //     {
    //         LoadNextLevel();
    //     }else if(Input.GetKeyDown(KeyCode.L))
    //     {
    //         quitarColicion = !quitarColicion; // toggle colission
    //     }
    // }

    // void OnCollisionEnter(Collision other){
    //     if(transicion || quitarColicion){ return; }
    //     switch (other.gameObject.tag)
    //     {
    //         case "Finish":
    //             Debug.Log("Finish");
    //             FinishSequence();
    //             break;
    //         case "Hit":
    //             Debug.Log("Hit");
    //             HitSequence();
    //             break;
    //     }
    // } 

    // void FinishSequence(){
    //     transicion = true;
    //     audioSource.Stop();
    //     audioSource.PlayOneShot(success);
    //     successParticles.Play();
    //     GetComponent<Movements>().enabled = false;
    //     Invoke("LoadNextLevel",delayLoad); 
    // }

    // void HitSequence(){
    //     transicion = true;
    //     audioSource.Stop();
    //     audioSource.PlayOneShot(crash);
    //     GetComponent<Movements>().enabled = false;
    //     Invoke("ReloadLevel",delayLoad); 
    // }

    // void LoadNextLevel()
    // {
    //     int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //     int nextSceneIndex = currentSceneIndex + 1 ;

    //     if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
    //     {
    //         nextSceneIndex = 0;
    //     }
    //    SceneManager.LoadScene(nextSceneIndex);
    // }

    // void ReloadLevel(){
    //     int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //     SceneManager.LoadScene(currentSceneIndex);
    // }

  
}
