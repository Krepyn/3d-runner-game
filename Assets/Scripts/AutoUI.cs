using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoUI : MonoBehaviour
{
    public GameObject coinText;
    public GameObject levelText;

    public GameObject health;
    public GameObject healthParent;

    void Start()
    {
        UIUpdate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UIUpdate() {
        coinText.GetComponent<Text>().text = Player.coins + "";
        levelText.GetComponent<Text>().text = "Level " + Player.currentLevel;

        foreach (Transform child in healthParent.transform) {
            GameObject.Destroy(child.gameObject);
        }

        for(int i = 0; i < Player.health; i++){
            Object.Instantiate(health, healthParent.transform);
        }

    }
}
