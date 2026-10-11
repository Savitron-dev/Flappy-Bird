using System.Globalization;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public enum GameState 
    {
        Ready,
        Playing,
        GameOver
    }
    public GameState currentState = GameState.Ready;
    public Rigidbody2D birdRb;
    public void StartGame()
    {
        currentState = GameState.Playing;
        birdRb.simulated = true;
    }
    public void GameOver()
    {
        currentState = GameState.GameOver;
        birdRb.simulated = false;
    }
}
