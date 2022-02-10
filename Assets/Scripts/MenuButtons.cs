using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject settingsPanel;
    public GameObject player;

    public static bool nextLevel = false;

    // Menu Pane

    public void OnMenuExitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void OnMenuButton() {
        menuPanel.SetActive(true);
        player.GetComponent<Player>().Stop();
    }

    public void OnMenuExitButton() {
        menuPanel.SetActive(false);
        player.GetComponent<Player>().Continue();
    }

    public void OnMenuSettingsButton() {
        settingsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    // Settings Pane
    public void OnSettingsExitButton() {
        settingsPanel.SetActive(false);
        player.GetComponent<Player>().Continue();
    }

    public void OnSettingsBackButton() {
        menuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    // Level End Pane
    public void OnNextLevel() {
        player.GetComponent<Player>().NextLevel();
        nextLevel = true;
    }

    public void OnSaveAndExitGame() {
        player.GetComponent<Player>().SavePlayerPrefs();
        OnMenuExitGame();
    }
}
