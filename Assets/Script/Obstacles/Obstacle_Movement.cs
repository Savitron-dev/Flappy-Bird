using UnityEngine;

public class Obstacle_Movement : MonoBehaviour
{
    public float speed = 5f;
    private float destroyX = -30f;
    private Rigidbody2D rb;
    public Game_Manager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gameManager.currentState != Game_Manager.GameState.Playing)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        rb.linearVelocity = Vector2.left * speed;

        if (transform.position.x <= destroyX)
        {
            DestroyObject();
        }
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}