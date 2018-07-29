using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningUltimate : MonoBehaviour {

    private Rigidbody2D myBody;

    private GameObject[] clouds;

    private float speed = 12f;

    private float ultimateStart = 0f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        clouds = GameObject.FindGameObjectsWithTag("Cloud");
        ultimateStart = Time.time;

        for (int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = Camera.main.transform.position;

            if(i == 0)
                temp.x += Random.Range(-4.5f, -2f);
            else
                temp.x += Random.Range(0f, 5.5f);

            temp.y = Camera.main.transform.position.y + 3.7f;
            clouds[i].transform.position = temp;
        }
    }

    private void FixedUpdate()
    {
        if (gameObject.activeInHierarchy && Player.instance.isAlive)
        {
            if (Time.time > ultimateStart + Player.instance.ultimateDuration)
                Destroy(this.gameObject);
            else
                Move();
        }
    }

    public void PlayAnim()
    {
        //anim = GetComponent<Animator>();
        //anim.Play("Cloud");
    }

    private void Move()
    {
        Vector3 temp = transform.position;
        temp.x += Time.deltaTime * speed;
        transform.position = temp;
    }
}
