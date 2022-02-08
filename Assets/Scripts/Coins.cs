using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider c){
        Debug.Log("Player picked up a coin.");
        player.GetComponent<Player>().CoinPickup();
        Destroy(this.gameObject);
    }
}
