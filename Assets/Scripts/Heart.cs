using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider c){
        Debug.Log("Player picked up a heart.");
        player.GetComponent<Player>().HealthPickup();
        Destroy(this.gameObject);
    }
}
