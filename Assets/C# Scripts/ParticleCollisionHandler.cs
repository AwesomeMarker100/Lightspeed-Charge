using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionHandler : MonoBehaviour
{

    [SerializeField] int scoreForHit = 1;
    // Start is called before the first frame update
    BoxCollider boxCollider;
    [SerializeField] GameObject EnemyDeathParticles;
    [SerializeField] Transform parentTransform;

    [SerializeField] int maxDamage = 5;

    Scoreboard scoreboard;

    void Start()
    {

        AddBoxCollider();
        scoreboard = FindObjectOfType<Scoreboard>();

       
      
    }

    // Update is called once per frame
    void AddBoxCollider()
    {
        boxCollider = this.gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(94.4f, 118.04f, 100.1f);

        boxCollider.isTrigger = false;

    }

    void OnParticleCollision(GameObject other)
    {

        TakingDamage();

        if (maxDamage <= 0)
        {

            FinishEnemy();


        }

       
        

    }

    void TakingDamage()
    {

        maxDamage--;
        scoreboard.AddScore(scoreForHit);


    }

    void FinishEnemy()
    {

        GameObject dyingEnemies = Instantiate(EnemyDeathParticles, this.transform.position, Quaternion.identity);

        
        dyingEnemies.transform.parent = parentTransform;

        Destroy(gameObject);


    }
}
