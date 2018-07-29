using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject pumpkinPrefab;

    private float speed = 0f;

    private float ultimateStart = 0f;

    private void Awake()
    {
        ultimateStart = Time.time;
        speed = Player.instance.maxspeed + 2f;
    }

    private void FixedUpdate()
    {
        if (Time.time > ultimateStart + Player.instance.ultimateDuration)
            Destroy(gameObject);
        else
        {
            Move();

            Instantiate(pumpkinPrefab, transform.position, pumpkinPrefab.transform.rotation);
        }
    }

    private void Move()
    {
        Vector3 temp = transform.position;
        temp.x += Time.deltaTime * speed;
        transform.position = temp;
    }

}
