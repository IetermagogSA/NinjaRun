using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamiliarCooldownText : MonoBehaviour {

    private int remainingFamiliarCooldown = 0;
    private TextMesh myTextMesh;

    private void Awake()
    {
        myTextMesh = GetComponent<TextMesh>();

        remainingFamiliarCooldown = (int)Familiars.instance.projectileCooldown;

        CreateText();

        StartCoroutine("CountDownFamiliarCooldown");
    }

    void CreateText()
    {
        var parent = transform.parent;

        var parentRenderer = parent.GetComponent<Renderer>();
        var renderer = GetComponent<Renderer>();
        renderer.sortingLayerID = parentRenderer.sortingLayerID;
        renderer.sortingOrder = parentRenderer.sortingOrder;


        Vector3 temp = parent.transform.position;
        temp.y += 0.6f;

        var pos = temp;
        myTextMesh.transform.position = temp;
        myTextMesh.text = remainingFamiliarCooldown.ToString();
    }

    IEnumerator CountDownFamiliarCooldown()
    {
        yield return new WaitForSeconds(1f);

        remainingFamiliarCooldown--;

        myTextMesh.text = remainingFamiliarCooldown.ToString();

        if (remainingFamiliarCooldown <= 0)
        {
            remainingFamiliarCooldown = (int)Familiars.instance.projectileCooldown;
            CreateText();
            Familiars.instance.ShootProjectile();
            StartCoroutine("CountDownFamiliarCooldown");
        }
        else
            StartCoroutine("CountDownFamiliarCooldown");


    }
}
