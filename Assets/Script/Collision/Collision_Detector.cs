using TMPro;
using UnityEngine;

public class Collision_Detector : MonoBehaviour
{
    public AudioSource wallHit;
    public AudioSource pipeHit;
    public Game_Manager gameManager;
    public GameObject restart;
    public Button_Manager buttonManager;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.gameObject.name);
        if (collision.collider.gameObject.name == "Top_Pipe" || collision.collider.gameObject.name == "Bottom_Pipe") 
        {
            pipeHit.Play();
        }
        if (collision.collider.gameObject.name == "Top_Wall" || collision.collider.gameObject.name == "Bottom_Wall") 
        {
            wallHit.Play();
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
            buttonManager.GameOver();
        }
    }
}
