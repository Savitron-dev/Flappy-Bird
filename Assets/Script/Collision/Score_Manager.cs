using TMPro;
using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    private int score = 0;
    public AudioSource bonus;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public void SetScore(int value)
    {
        score = value;
    }
    public int GetScore()
    {
        return score;
    }
    public void AddScore() 
    {
        bonus.Play();
        score++;
        scoreText.text = score.ToString();
        highScoreText.text = "High Score: " + score.ToString();
    }
}
