using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife instance;

    [SerializeField]
    private Sprite[] lifeSprites;

    private Image lifeImage;


    private void Awake()
    {
        if (instance == null)
            instance = this;

        lifeImage = GetComponent<Image>();
    }

    public void updateLifeImage()
    {
        switch(Player.instance.LifeCounter)
        {
            case 0:
                lifeImage.sprite = lifeSprites[0]; // Life empty
                break;
            case 1:
                lifeImage.sprite = lifeSprites[1]; // Life 25%
                break;
            case 2:
                lifeImage.sprite = lifeSprites[2]; // Life 50%
                break;
            case 3:
                lifeImage.sprite = lifeSprites[3]; // Life 75%
                break;
            case 4:
                lifeImage.sprite = lifeSprites[4]; // Life 100%
                break;
            default:
                break;
        }
    }

}
