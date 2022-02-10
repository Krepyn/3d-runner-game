using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlock : MonoBehaviour
{
    public GameObject RoadBlocks;

    private GameObject player;

    void OnTriggerEnter(Collider c) {
        if(c.gameObject.tag == "Player"){
            player = c.gameObject;
            Debug.Log("Road Block hit.");
            RoadBlocks.GetComponent<RoadBlocks>().Col(player);
        }
    }
}
