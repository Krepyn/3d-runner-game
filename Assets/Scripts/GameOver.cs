using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject scoreText;

    private int coinsCollected;
    private int health;
    private int score;
    private int totalScore;

    public void gOver() {
        coinsCollected = Player.coinsCollectedThisLevel;
        health = Player.healthThisLevel;
        score = coinsCollected * 1 + health * 100;
        totalScore = Player.totalScore + score;

        Player.totalScore += score;

        gameOverPanel.SetActive(true);
        scoreText.GetComponent<Text>().text = coinsCollected +" coin x 1\n" +
                                              health + " health x 100\n" +
                                              "<b>Score:</b> " + score +
                                              "\n<b>Total Score:</b> " + totalScore;
    }
}
