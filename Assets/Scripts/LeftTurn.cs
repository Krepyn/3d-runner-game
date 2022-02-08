using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTurn : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter(Collider c) {
        Debug.Log("Turning.");
        // player.GetComponent<Player>().LeftTurn();
    }
}
