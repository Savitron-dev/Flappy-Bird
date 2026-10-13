using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Button_Manager : MonoBehaviour
{
    public GameObject pause;
    public GameObject restart;
    public GameObject play;
    public GameObject bg;
    public GameObject tapHere;
    public GameObject menu;
    public GameObject quit;
    public GameObject gameOver;
    public GameObject bird;
    public TMP_Text overScoreText;
    public TMP_Text overHighScoreText;
    public Game_Manager gameManager;
    public Score_Manager score;
    public Obstacle_Spawner obstacle_Spawner;
    void Start()
    {
        tapHere.SetActive(true);
        Time.timeScale = 0f;
    }
    public void TapHere() 
    {
        Time.timeScale = 1f;
        tapHere.SetActive(false);
        gameManager.StartGame();
    }
    public void Pause()
    {
        pause.SetActive(false);
        bg.SetActive(true);
        play.SetActive(true);
        menu.SetActive(true);
        quit.SetActive(true);
        restart.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Play()
    {
        Time.timeScale = 1f;
        bg.SetActive(false);
        play.SetActive(false);
        restart.SetActive(false);
        menu.SetActive(false);
        quit.SetActive(false);
        pause.SetActive(true);
    }

    public void GameOver() 
    {
        pause.SetActive(false);
        bg.SetActive(true);        
        restart.SetActive(true);        
        gameOver.SetActive(true);
        menu.SetActive(true);
        quit.SetActive(true);
        overScoreText.text = "Score: " + score.GetScore();
        overHighScoreText.text = "High Score: " + score.GetScore();
        score.SetScore(0);
    }
    public void Restart() 
    {
        Time.timeScale = 0f;    
        bg.SetActive(false);
        play.SetActive(false);
        restart.SetActive(false);
        gameOver.SetActive(false);
        menu.SetActive(false);
        quit.SetActive(false);
        pause.SetActive(true);
        tapHere.SetActive(true);
        obstacle_Spawner.ClearObstacles();
        bird.transform.position = new Vector3(-2f, 3f, 0f);
        bird.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        score.scoreText.text = score.GetScore().ToString();
    }
    public void Menu() 
    {    
        Time.timeScale = 1f;
    }
    public void Quit() 
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
