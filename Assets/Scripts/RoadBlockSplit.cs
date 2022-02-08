using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlockSplit : MonoBehaviour
{
    void OnCollisionEnter(Collision c) {
        if (c.gameObject.tag == "Player")
            Physics.IgnoreCollision(c.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
    }
}
