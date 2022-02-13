using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public GameObject UIHandler;
    public GameObject levelEndPanel;
    public GameObject gameEndPanel;

    private GameObject player;

    private void OnTriggerEnter(Collider c){
        if(c.gameObject.tag == "Player"){
            player = c.gameObject;

            Debug.Log("Level end.");
            UIHandler.GetComponent<levelEnd>().End();
            StartCoroutine(player.GetComponent<Player>().LevelEnd());
        }
    }
}
