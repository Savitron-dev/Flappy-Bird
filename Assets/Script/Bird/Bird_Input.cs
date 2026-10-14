using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bird_Input : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    public AudioSource fly;
    public Game_Manager gameManager;
    [SerializeField] private Animator flyBird;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            flyBird.SetBool("isFly", true);
            Jump();
        }
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                flyBird.SetBool("isFly", true);
                Jump();
            }
        }
        else 
        {
            flyBird.SetBool("isFly", false);        
        }
    }
    void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            if (gameManager.currentState == Game_Manager.GameState.Ready) 
            {
                gameManager.StartGame();
            }
            if (gameManager.currentState == Game_Manager.GameState.Playing) 
            {
                fly.Play();
                Vector2 move = new Vector2(0, jumpForce);
                rb.AddForce(move, ForceMode2D.Impulse);
            }
        }
    }
}