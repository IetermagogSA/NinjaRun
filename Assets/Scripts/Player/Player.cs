using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public static Player instance;

    public float speed = 3f;

    public float maxspeed = 10f;

    public bool isAlive;

    public bool isAttacking;

    private float projectileCooldown = 2f, projectileTimeStamp = 0f;
    private float shieldCooldown = 15f, shieldTimeStamp = 0f;
    private float ultimateCooldown = 30f, ultimateTimeStamp = 0f;
    private float meleeCooldown = 1f, meleeTimeStamp = 0f;

    public float shieldDuration = 7f;
    public float ultimateDuration = 25f;

    public float maxFireballs = 0f;
    public float currentFireballs = 0f;

    public int LifeCounter = 4;

    private bool hasFamiliar = true; // this should be set to false

    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private GameObject shieldPrefab;

    [SerializeField]
    public GameObject ultimatePrefab;

    [SerializeField]
    public GameObject familiarPrefab;

    [HideInInspector]
    public int jumpCounter;

    float jumpHeight = 6f;

    Animator anim;
    Rigidbody2D myBody;

    public TextMesh ShieldDurationText;

    private Image ultimateCooldownImage, shieldCooldownImage, projectileCooldownImage, meleeCooldownImage;


    private void Awake()
    {

        jumpCounter = 0;
        isAlive = true;

        if (instance == null)
            instance = this;

        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();

        SetCameraOffsetX();

        maxFireballs = 30f;

        if (hasFamiliar)
            CreateFamiliar();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (isAlive)
        {
            Move();
            CooldownButtons();
        }
    }

    public void SetAttackingFalse()
    {
        isAttacking = false;
        anim.SetBool("isAttacking", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            jumpCounter = 0;
            Run();
        }
    }

    public void Jump()
    {
        if (jumpCounter < 2)
        {
            jumpCounter++;

            anim.SetBool("isJumping", true);

            myBody.velocity = new Vector2(0, jumpHeight);
        }
    }

    public void Run()
    {
        anim.SetBool("isJumping", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isRunning", true);
    }

    public IEnumerator Die()
    {
        if (LifeCounter > 0)
        {
            LifeCounter--;
            PlayerLife.instance.updateLifeImage();
        }
        else
        {
            isAlive = false;
            anim.Play("NinjaBoyDead");
            AnimatorStateInfo currInfo = anim.GetCurrentAnimatorStateInfo(0);
            yield return new WaitForSeconds(currInfo.length);
            Destroy(this.gameObject);
        }
    }

    public void SetCameraOffsetX()
    {
        CameraScript.offsetX = Camera.main.transform.position.x - transform.position.x;
    }

    public float GetPositionX()
    {
        return instance.transform.position.x;
    }

    public void MeleeAttack()
    {
        if (meleeTimeStamp == 0 || Time.time > meleeTimeStamp + meleeCooldown)
        {
            isAttacking = true;

            meleeTimeStamp = Time.time;

            meleeCooldownImage = EventSystem.current.currentSelectedGameObject.GetComponentsInParent<Image>()[0]; // Get only the parent and not the child - this will be at index 1
            meleeCooldownImage.fillAmount = 0;

            if (jumpCounter >= 1)
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("isAttacking", true);
            }
            else
            {
                anim.SetTrigger("isAttackingTrigger");
            }
        }
    }

    public void ProjectileAttack()
    {
        if (projectileTimeStamp == 0 || Time.time > projectileTimeStamp + projectileCooldown)
        {
            projectileTimeStamp = Time.time;

            if (jumpCounter >= 1)
                anim.SetTrigger("isJumpingThrow");
            else
                anim.SetTrigger("isThrowing");


            projectileCooldownImage = EventSystem.current.currentSelectedGameObject.GetComponentsInParent<Image>()[0]; // Get only the parent and not the child - this will be at index 1
            projectileCooldownImage.fillAmount = 0;

            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        
    }

    public void ShieldPlayer()
    {
        if (shieldTimeStamp == 0 || Time.time > shieldTimeStamp + shieldCooldown)
        {
            shieldTimeStamp = Time.time + shieldDuration;

            shieldCooldownImage = EventSystem.current.currentSelectedGameObject.GetComponentsInParent<Image>()[0]; // Get only the parent and not the child - this will be at index 1
            shieldCooldownImage.fillAmount = 0;

            Instantiate(shieldPrefab, transform.position, Quaternion.identity);
        }
    }

    public void UltimateAttack()
    {
        if (ultimateTimeStamp == 0 || Time.time > ultimateTimeStamp + ultimateCooldown)
        {
            ultimateTimeStamp = Time.time + ultimateDuration;

            currentFireballs = 0;

            ultimateCooldownImage = EventSystem.current.currentSelectedGameObject.GetComponentsInParent<Image>()[0]; // Get only the parent and not the child - this will be at index 1
            ultimateCooldownImage.fillAmount = 0;

            Instantiate(ultimatePrefab, transform.position, ultimatePrefab.transform.rotation);
        }
    }

    private void Move()
    {
        Vector3 temp = transform.position;
        temp.x += Time.deltaTime * speed;
        transform.position = temp;
    }

    private void CooldownButtons()
    {
        if (shieldCooldownImage != null && shieldCooldownImage.fillAmount != 1)
        {
            float shieldTotalDuration = shieldDuration + shieldCooldown;
            shieldCooldownImage.fillAmount += 1.0f / shieldTotalDuration * Time.deltaTime;
        }

        if (ultimateCooldownImage != null && ultimateCooldownImage.fillAmount != 1)
        {
            float ultimateCooldownTotalDuration = ultimateDuration + ultimateCooldown;
            ultimateCooldownImage.fillAmount += 1.0f / ultimateCooldownTotalDuration * Time.deltaTime;
        }

        if (projectileCooldownImage != null && projectileCooldownImage.fillAmount != 1)
        {
            float projectileCooldownTotalDuration = projectileCooldown;
            projectileCooldownImage.fillAmount += 1.0f / projectileCooldownTotalDuration * Time.deltaTime;
        }

        if (meleeCooldownImage != null && meleeCooldownImage.fillAmount != 1)
        {
            float meleeTotalCooldownDuration = meleeCooldown;
            meleeCooldownImage.fillAmount += 1.0f / meleeTotalCooldownDuration * Time.deltaTime;
        }
    }

    private void CreateFamiliar()
    {
        // Determine from user settings which familiar should be spawned here

        Instantiate(familiarPrefab, transform.position, familiarPrefab.transform.rotation);
    }
}
