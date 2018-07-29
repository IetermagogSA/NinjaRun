using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour {

    public GameObject[] Candy;

    private int maxLevelCandy = 1;

    private float minSpawnRate = 6f;
    private float maxSpawnRate = 10f;

    private float offSetY = 3f;

    private void Awake()
    {
        StartCoroutine(SpawnCandy());
    }

    IEnumerator SpawnCandy()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));

        int index = Random.Range(0, maxLevelCandy);
        if(!Candy[index].activeInHierarchy)
        {
            // Reposition the spawned enemy
            Vector3 temp = transform.position;
            temp.y = Random.Range(-(Camera.main.orthographicSize * 1f) + offSetY, Camera.main.orthographicSize * 1.2f - offSetY); // Range the y from 0 to the maximum size of the screen height

            Instantiate(Candy[index], temp, Candy[index].transform.rotation);
        }

        StartCoroutine(SpawnCandy());
    }
    
}
