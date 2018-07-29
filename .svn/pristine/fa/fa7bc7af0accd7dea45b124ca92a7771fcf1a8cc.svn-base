using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour {

    private Image cooldownImage;

    void Awake()
    {
        cooldownImage = GetComponent<Image>();
        cooldownImage.fillAmount = 0;
    }

    void Update()
    {
        while(cooldownImage.fillAmount < 1)
            cooldownImage.fillAmount += 0.1f;
    }
}
