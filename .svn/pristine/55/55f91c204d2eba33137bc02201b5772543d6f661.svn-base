using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Familiars : MonoBehaviour
{

    public static Familiars instance;

    [SerializeField]
    private float speed = 10f;

    public GameObject projectile;

    public float offSetX = 1;
    public float offSetY = -1f;

    private Rigidbody2D myBody;

    private float shootTimeStamp = 0f;

    public float projectileCooldown = 10f;

    public TextMesh familiarCooldownText;


    private void Awake()
    {
        if (instance == null)
            instance = this;

        myBody = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update ()
    {
        Move();

        //ShootProjectile();
    }

    private void Move()
    {
        if (Player.instance.isAlive)
        {
            Vector3 temp = transform.position;
            temp.x = Player.instance.transform.position.x + offSetX;
            temp.y = Player.instance.transform.position.y + offSetY;

            transform.position = temp;
        }
    }

    public void ShootProjectile()
    {
        if (Time.time > shootTimeStamp + projectileCooldown)
        {
            shootTimeStamp = Time.time;
            Instantiate(projectile, transform.position, projectile.transform.rotation);
        }
    }
}
