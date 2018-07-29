using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollector : MonoBehaviour {

    Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
            Destroy(collision.gameObject);
    }
}
