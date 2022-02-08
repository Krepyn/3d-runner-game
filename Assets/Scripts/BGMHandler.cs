using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMHandler : MonoBehaviour
{
    public GameObject currentBGM;

    void Awake()
    {
        if(GameObject.FindGameObjectsWithTag("bgm").Length > 1){
            Debug.Log("Found old bgm object.");
            Destroy(currentBGM);
        } else {
            Debug.Log("Music played.");
            currentBGM.GetComponent<BGM>().PlayMusic();
        }
    }
}
