using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelEnd : MonoBehaviour
{
    public GameObject levelEndPanel;
    public GameObject gameEndPanel;
    public GameObject scoreText; // levelEnd Score
    public GameObject scoreText2; // gameEnd Score

    private int coinsCollected;
    private int health;
    private int totalScore;
    private int score;

    public void End() {
        coinsCollected = Player.coinsCollectedThisLevel;
        health = Player.healthThisLevel;
        score = coinsCollected * 1 + health * 100;
        totalScore = Player.totalScore + score;

        Player.totalScore += score;

        if(Player.currentLevel < Player.maxLevel){
            levelEndPanel.SetActive(true);
            scoreText.GetComponent<Text>().text = coinsCollected +" coin x 1\n" +
                                                  health + " health x 100\n" +
                                                  "<b>Score:</b> " + score +
                                                  "\n<b>Total Score:</b> " + totalScore;

        } else {
            gameEndPanel.SetActive(true);
            scoreText2.GetComponent<Text>().text = coinsCollected +" coin x 1\n" +
                                                  health + " health x 100\n" +
                                                  "<b>Score:</b> " + score +
                                                  "\n<b>Total Score:</b> " + totalScore;
        }
    }
}
