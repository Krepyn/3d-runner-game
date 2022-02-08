using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject player;

    public void OnSaveGame() {

    }

    public void OnExitGame() {
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

    public void OnNextLevel() {
        player.GetComponent<Player>().NextLevel();
    }

    public void OnSaveAndExitGame() {
        player.GetComponent<Player>().SavePlayerPrefs();
        OnExitGame();
    }
}
