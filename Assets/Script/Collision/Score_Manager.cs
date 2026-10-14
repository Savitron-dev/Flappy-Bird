using TMPro;
using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    private int score = 0;
    private int highScore;
    public AudioSource bonus;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }
    public void SetScore(int value)
    {
        score = value;
    }
    public int GetScore()
    {
        return score;
    }
    public int GetHighScore()
    {
        return highScore;
    }
    public void AddScore() 
    {
        bonus.Play();
        score++;
        if (score >= highScore) 
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        scoreText.text = score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
