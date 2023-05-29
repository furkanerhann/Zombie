using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public int scoreAmountOnKill;
    public int currentScore;
    public int highScore;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    void Start()
    {
        InitVariables();
        UpdateHighScore();
    }

    private void InitVariables()
    {
        currentScore = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void AddScore()
    {
        currentScore += scoreAmountOnKill;
        scoreText.text = currentScore.ToString();

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScore();
        }
    }
    private void UpdateHighScore()
    {
        highScoreText.text = highScore.ToString();
    }
}
