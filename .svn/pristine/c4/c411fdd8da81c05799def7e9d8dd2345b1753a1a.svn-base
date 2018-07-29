using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour
{

    private GameObject[] backgrounds;
    private GameObject[] grounds;

    private float backgroundsLastX, groundsLastX;

    private void Awake()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        grounds = GameObject.FindGameObjectsWithTag("Ground");

        backgroundsLastX = backgrounds[0].transform.position.x;
        groundsLastX = grounds[0].transform.position.x;

        for (int i = 1; i < backgrounds.Length; i++)
        {
            if (backgrounds[i].transform.position.x > backgroundsLastX)
                backgroundsLastX = backgrounds[i].transform.position.x;
        }

        for (int i = 1; i < grounds.Length; i++)
        {
            if (grounds[i].transform.position.x > groundsLastX)
                groundsLastX = grounds[i].transform.position.x;
        }
    }

    // REMEMBER: The Box Collider determines the size of the background image!!
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.tag == "Background")
        //{
        //    Vector3 temp = collision.transform.position;
        //    float width = ((BoxCollider2D)collision).size.x;
        //    temp.x = backgroundsLastX + width;

        //    collision.transform.position = temp;
        //    backgroundsLastX = collision.transform.position.x;
        //}
        //else if (collision.tag == "Ground")
        //{
        //    Vector3 temp = collision.transform.position;
        //    float width = ((BoxCollider2D)collision).size.x * 0.35f; // Multiply by the scaling factor to determine the correct size
        //    temp.x = groundsLastX + width;

        //    collision.transform.position = temp;
        //    groundsLastX = collision.transform.position.x;
        //}
        //else if(collision.tag == "Enemies" || collision.tag == "Platform")
        if (collision.tag == "Enemies" || collision.tag == "Platform")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.tag == "Collectables")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
