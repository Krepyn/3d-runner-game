using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public GameObject player;
    public GameObject levelEndPanel;

    private void OnTriggerEnter(Collider c){
        Debug.Log("Level end.");
        levelEndPanel.SetActive(true);
        StartCoroutine(player.GetComponent<Player>().LevelEnd());
    }
}
