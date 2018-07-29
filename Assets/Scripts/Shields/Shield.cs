using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    //Animator anim;
    Rigidbody2D myBody;

    private float offset = 0.25f;


    //private float shieldduration = 7f, shieldStart = 0f;
    private float shieldStart = 0f;


    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        shieldStart = Time.time;
        PlayAnim();

        // Start the countdown timer
        Instantiate(Player.instance.ShieldDurationText, transform.parent);
        Player.instance.ShieldDurationText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if(gameObject.activeInHierarchy && Player.instance.isAlive)
        {
            if (Time.time > shieldStart + Player.instance.shieldDuration)
                Destroy(this.gameObject);
            else
            {
                myBody.transform.position = new Vector3(Player.instance.transform.position.x + offset, Player.instance.transform.position.y + offset, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.tag == "Enemies")
        //{
        //    Destroy(collision.gameObject);
        //}
    }

    public void PlayAnim()
    {
        //anim = GetComponent<Animator>();
        // Changes will need to be made here to select which shield animation should be playing
        //anim.Play("LightningShield2");
    }
}
