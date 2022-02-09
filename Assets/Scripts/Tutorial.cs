using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialPanel;

    // Update is called once per frame
    void Update()
    {
        if(!Player.isLevelStart)
            tutorialPanel.SetActive(false);
    }
}
