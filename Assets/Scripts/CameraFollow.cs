using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject mainCam;
    public GameObject player;

    void Update() {
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = player.transform.position.z;
        mainCam.transform.position = new Vector3(x + 4, y + 3.5f, z + 4);
    }
}
