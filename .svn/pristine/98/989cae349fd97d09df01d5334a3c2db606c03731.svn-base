using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public GameObject[] platforms;

    private List<GameObject> createdPlatforms;

    private float minSpawnRate = 3f;
    private float maxSpawnRate = 5f;

    private float offSetY = 3f;

    private void Awake()
    {
        createdPlatforms = new List<GameObject>();
        DetermineSpawnRate();
        StartCoroutine(SpawnPlatform());
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // This function will later be refined to make use of user settings to determine how often and which platforms can be spawned
    void DetermineSpawnRate()
    {
        minSpawnRate = 3f;
        maxSpawnRate = 8f;
    }


    IEnumerator SpawnPlatform()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));

        int index = Random.Range(0, platforms.Length - 1);
        if (!platforms[index].activeInHierarchy)
        {
            // Reposition the spawned platform
            Vector3 temp = transform.position;

            int platformAmount = Random.Range(1, 4); // 4 will be excluded

            for (int i = 1; i <= platformAmount; i++)
            {
                temp.x += Random.Range(6f, 14f);

                switch (i)
                {
                    case 1:
                        temp.y = Random.Range(-(Camera.main.orthographicSize * 0.8f) + offSetY, -(Camera.main.orthographicSize * 1f - offSetY)); // Spawn platform lower than half of the screen
                        break;
                    case 2:
                        temp.y = Random.Range(-(Camera.main.orthographicSize * 0.5f) + offSetY, -(Camera.main.orthographicSize * 0.7f - offSetY)); // Spawn platform middlish part of the screen
                        break;
                    case 3:
                        temp.y = Random.Range(-(Camera.main.orthographicSize * 0.2f) + offSetY, -(Camera.main.orthographicSize * 0.4f - offSetY)); // Spawn platform higher than half of the screen
                        break;
                }

                GameObject newPlatform = (GameObject)Instantiate(platforms[index], temp, platforms[index].transform.rotation);
                createdPlatforms.Add(newPlatform);
            }
        }

        StartCoroutine(SpawnPlatform());
    }
}
