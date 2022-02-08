using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public GameObject player;

    public int amount = 1;

    private void OnTriggerEnter(Collider c){
        Debug.Log("Player picked up a coin.");
        player.GetComponent<Player>().CoinPickup(amount);
        Destroy(this.gameObject);
    }
}
