using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMHandler : MonoBehaviour
{
    public GameObject currentBGM;

    private float audioVolume;

    void Awake()
    {
        if(GameObject.FindGameObjectsWithTag("bgm").Length > 1){
            //Debug.Log("Found old bgm object.");
            Destroy(currentBGM);
        } else {
            //Debug.Log("Music played.");

            audioVolume = PlayerPrefs.GetFloat("Volume", -1);
            if(audioVolume != -1)
                currentBGM.GetComponent<AudioSource>().volume = audioVolume;

            currentBGM.GetComponent<BGM>().PlayMusic();
        }
    }
}
