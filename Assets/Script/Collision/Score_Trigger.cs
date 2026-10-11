using UnityEngine;

public class Score_Trigger : MonoBehaviour
{
    public Score_Manager scoreManager;
    private void Start()
    {
        scoreManager = FindAnyObjectByType<Score_Manager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scoreManager.AddScore();
        }
    }    
}
