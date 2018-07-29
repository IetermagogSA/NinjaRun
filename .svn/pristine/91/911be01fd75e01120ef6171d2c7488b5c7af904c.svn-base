using UnityEngine;
using System.Collections;

public class ShieldDurationText : MonoBehaviour
{
    private int remainingShieldDuration = 0;
    private TextMesh myTextMesh;

    private void OnEnable()
    {
        myTextMesh = GetComponent<TextMesh>();

        remainingShieldDuration = (int)Player.instance.shieldDuration;

        CreateText();

        StartCoroutine("CountDownShieldDuration");
    }

    void CreateText()
    {
        var parent = transform.parent;

        var parentRenderer = parent.GetComponent<Renderer>();
        var renderer = GetComponent<Renderer>();
        renderer.sortingLayerID = parentRenderer.sortingLayerID;
        renderer.sortingOrder = parentRenderer.sortingOrder;


        Vector3 temp = parent.transform.position;
        temp.x += 0.15f;
        temp.y += 2f;

        var pos = temp;
        myTextMesh.transform.position = temp;
        myTextMesh.text = remainingShieldDuration.ToString();
    }

    IEnumerator CountDownShieldDuration()
    {
        yield return new WaitForSeconds(1f);

        remainingShieldDuration--;

        myTextMesh.text = remainingShieldDuration.ToString();

        if (remainingShieldDuration <= 0)
        {
            gameObject.SetActive(false);
        }
        else
            StartCoroutine("CountDownShieldDuration");


    }
}