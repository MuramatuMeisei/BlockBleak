using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject clearText;
    [SerializeField] TextMeshProUGUI resultScore;
    [SerializeField] TextMeshProUGUI resultTime;
    [SerializeField] TextMeshProUGUI resultLife;
    [SerializeField] TextMeshProUGUI resultTotalScore;
    [SerializeField] TextMeshProUGUI highScoreUI;

    public void SetScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void SetTimerText(float leftTime)
    {
        timerText.text = "Time: " + Mathf.RoundToInt(leftTime);
    }

    public void ShowGameOver()
    {
        gameOverText.SetActive(true);
    }

    public void ShowClear()
    {
        clearText.SetActive(true);
    }

    public void ShowResult(int score, float leftTime, int ballCount, int totalScore, int highScore)
    {
        resultScore.text = "Score: " + score;
        resultTime.text = "Time: " + Mathf.RoundToInt(leftTime) + "x 100 = " + Mathf.RoundToInt(leftTime) * 100;
        resultLife.text = "Life: " + ballCount + "x 500 = " + ballCount * 500;
        resultTotalScore.text = "Total Score: " + totalScore;

        if (highScoreUI != null)
        {
            highScoreUI.text = "High Score: " + highScore;
        }
    }

    public void HideResult()
    {
        gameOverText.SetActive(false);
        clearText.SetActive(false);
    }
}
