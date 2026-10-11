using UnityEngine;
using static UnityEngine.Audio.ProcessorInstance;

public class Background_Spawner : MonoBehaviour
{
    public GameObject bG;
    public Game_Manager gameManager;

    public float reactionDelay = 20f;
    private float time = 0f;

    void Update()
    {
        if (gameManager.currentState != Game_Manager.GameState.Playing) 
        {
            return;
        }
        time += Time.deltaTime;
        if (time >= reactionDelay)
        {
            BGSpawner();
            time = 0f;
        }
        
    }
    void BGSpawner()
    {
        Vector3 spawnPoint = new Vector3(14.14f, 0, 0f);
        Instantiate(bG, spawnPoint, Quaternion.identity);
        Obstacle_Movement movement = bG.GetComponent<Obstacle_Movement>();
        movement.gameManager = gameManager;
    }   
}
