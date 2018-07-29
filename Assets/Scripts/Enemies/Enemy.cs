using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Player.instance.isAttacking == false)
        {
            StartCoroutine(Player.instance.Die());

            StartCoroutine(Die());
        }
        else if (collision.tag == "Projectile")
        {
            //Destroy(collision.gameObject);
            StartCoroutine(Die());
        }
        else if ((collision.tag == "Player" && Player.instance.isAttacking) || (collision.tag == "PlayerCollector" && Player.instance.isAttacking) || collision.tag == "Shield" || collision.tag == "Lightning" || collision.tag == "Ultimate")
        {
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        anim.Play("Dead");
        AnimatorStateInfo currInfo = anim.GetCurrentAnimatorStateInfo(0);
        string info = anim.GetLayerName(0);
        yield return new WaitForSeconds(currInfo.normalizedTime);
        Destroy(gameObject);
    }
}
