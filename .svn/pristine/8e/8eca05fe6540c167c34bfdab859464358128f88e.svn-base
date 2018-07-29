using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public static float offsetX;

    // Update is called once per frame
    void Update()
    {
        if(Player.instance.isAlive)
            MoveTheCamera();
    }

    void MoveTheCamera()
    {
        Vector3 temp = transform.position;
        temp.x = Player.instance.GetPositionX() + offsetX;

        transform.position = temp;
    }
}
