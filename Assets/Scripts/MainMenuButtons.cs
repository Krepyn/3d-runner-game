using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject loadGameButton;
    public GameObject settingsPanel;
    public static bool loadGame = false;

    private int currentLevel;

    public void Start() {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", -1);
        if(currentLevel != -1){
            loadGameButton.GetComponent<Button>().interactable = true;
        }
    }

    // Main Menu
    public void OnNewGame() {
        PlayerPrefs.SetInt("Health", 3);
        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("CurrentLevel", 1);
        PlayerPrefs.Save();

        SceneManager.LoadScene(1);
    }

    public void OnLoadGame() {
        SceneManager.LoadScene(currentLevel);
        loadGame = true;
    }

    public void OnSettings() {
        settingsPanel.SetActive(true);
    }

    // Settings
    public void OnSettingsExitButton() {
        settingsPanel.SetActive(false);
    }
}
