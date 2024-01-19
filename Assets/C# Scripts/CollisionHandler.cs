using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("Delay in seconds")][SerializeField] float levelLoadDelay = 2f;
    [Tooltip("ParticleSystem")][SerializeField] ParticleSystem deathParticles;

    // Start is called before the first frame update
    void Start()
    {
        deathParticles.gameObject.SetActive(false);
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {

       InitiateDeathSequence();

    }

    private void InitiateDeathSequence()
    {

        deathParticles.gameObject.SetActive(true);

        SendMessage("DeathSequence");
        Invoke("RestartLevel", levelLoadDelay);
        

    }

    private void RestartLevel()
    {

        SceneManager.LoadScene(1);


    }
}
