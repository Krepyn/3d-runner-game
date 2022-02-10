using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private GameObject player;
    public int amount = 1;

    private void OnTriggerEnter(Collider c){
        if(c.gameObject.tag == "Player"){
            player = c.gameObject;
            Debug.Log("Player picked up a coin.");
            player.GetComponent<Player>().CoinPickup(amount);
            Destroy(this.gameObject);
        }
    }
}
