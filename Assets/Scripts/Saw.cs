using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{

    private GameObject player;
    // Update is called once per frame
    private void OnTriggerEnter(Collider c){
        if(c.gameObject.tag == "Player"){
            player = c.gameObject;
            Debug.Log("Player got hit by a saw.");
            player.GetComponent<Player>().GetHit();
        }
    }
}
