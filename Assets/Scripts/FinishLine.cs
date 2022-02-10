using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public GameObject levelEndPanel;
    public GameObject gameEndPanel;

    private GameObject player;

    private void OnTriggerEnter(Collider c){
        if(c.gameObject.tag == "Player"){
            player = c.gameObject;
            Debug.Log("Level end.");

            if(Player.currentLevel < Player.maxLevel){
                levelEndPanel.SetActive(true);
            } else
                gameEndPanel.SetActive(true);

            StartCoroutine(player.GetComponent<Player>().LevelEnd());
        }
    }
}
