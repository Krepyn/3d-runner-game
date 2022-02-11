using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    private GameObject player;

    private void OnTriggerEnter(Collider c){
        if(c.gameObject.tag == "Player"){
            player = c.gameObject;
            
            //Debug.Log("Player picked up a heart.");
            player.GetComponent<Player>().HealthPickup();
            Destroy(this.gameObject);
        }
    }
}
