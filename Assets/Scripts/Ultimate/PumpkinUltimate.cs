using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PumpkinUltimate : MonoBehaviour {

    private Rigidbody2D myBody;

    Animator anim;

    [SerializeField]
    private float speed = 25f;

    public Sprite[] pumpkinSprite;

    private SpriteRenderer myPumpkinImage;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myPumpkinImage = GetComponent<SpriteRenderer>();

        float scale = Random.Range(0.1f,0.35f);
        transform.localScale = new Vector3(scale, scale, 0);

        myPumpkinImage.sprite = pumpkinSprite[Random.Range(0, 3)];
        Position();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            Destroy(gameObject);
        }
        else if(collision.tag == "Enemies")
        {
            Destroy(gameObject);
        }
    }

    private void Position()
    {
        Vector3 temp = transform.position;
        temp.x += Random.Range(-12.5f, 5.5f);
        temp.y = Camera.main.transform.position.y + Random.Range(-1f, 7.5f);
        transform.position = temp;
    }

    private void Move()
    {
        Vector3 temp = transform.position;
        temp.x += Time.deltaTime * speed;
        transform.position = temp;
    }
}
