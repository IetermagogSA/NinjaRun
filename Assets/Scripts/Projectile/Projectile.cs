using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float maxSpeed = 30f;

    Animator anim;

    private Rigidbody2D myBody;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        Vector3 temp = transform.position;
        temp.x += 1f;
        myBody.transform.position = temp;
        //PlayAnim();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (!anim.GetBool("isEggBroken"))
        {
            if (gameObject.activeInHierarchy)
            {
                if (myBody.velocity.x <= maxSpeed)
                    myBody.velocity += new Vector2(speed, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemies")
        {
            StartCoroutine(PlayAnim());
        }
    }

    public IEnumerator PlayAnim()
    {
        myBody.velocity = Vector3.zero;

        anim.SetBool("isEggBroken",true);
        AnimatorStateInfo currInfo = anim.GetCurrentAnimatorStateInfo(0);
        string info = anim.GetLayerName(0);
        yield return new WaitForSeconds(currInfo.normalizedTime);
        Destroy(gameObject);
    }
}
