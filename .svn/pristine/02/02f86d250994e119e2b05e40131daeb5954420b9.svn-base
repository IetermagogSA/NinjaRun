using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] Enemies;

    private int maxLevelEnemy = 2;

    private float minSpawnRate = 0.2f;
    private float maxSpawnRate = 5f;

    private float offSetY = 2.5f;

    private void Awake()
    {
        DetermineMaxLevelAndSpawnRate();
        StartCoroutine(SpawnEnemy());
    }

    // Use this for initialization
    void Start ()
    {
        
    }
    
    // Update is called once per frame
    void Update ()
    {
        
    }

    // This function will later be refined to make use of user settings to determine how often and which enemies can be spawned
    void DetermineMaxLevelAndSpawnRate()
    {
        maxLevelEnemy = 2;
        minSpawnRate = 0.2f;
        maxSpawnRate = 5f;
    }

    enum EnemyTypes
    {
        Ghost,
        ZombieBoy,
        ZombieGirl
    };

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));

        int index = Random.Range(0, maxLevelEnemy + 1);
        if (!Enemies[index].activeInHierarchy)
        {
            // Reposition the spawned enemy
            Vector3 temp = transform.position;

            if((EnemyTypes)index == EnemyTypes.Ghost)
                // Range the y from 0 to the maximum size of the screen height: Ghosts can spawn anywhere since they can fly
                temp.y = Random.Range(-(Camera.main.orthographicSize * 1f) + offSetY, Camera.main.orthographicSize * 1.2f - offSetY); 
            else
                // If enemy has a body and will fall into the scene, always spawn it at the top - it may fall on a platform for extra fun!
                temp.y = Camera.main.orthographicSize; 

            Instantiate(Enemies[index], temp, Enemies[index].transform.rotation);
        }

        StartCoroutine(SpawnEnemy());
    }
}
