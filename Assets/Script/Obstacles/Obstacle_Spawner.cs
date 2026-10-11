using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Obstacle_Spawner : MonoBehaviour
{
    public GameObject pipe;
    public GameObject platform;
    private float minGapY = 3;
    private float maxGapY = 9;
    public float reactionDelay = 2.5f;
    private float time = 0f;
    public Game_Manager gameManager;

    public Vector3 spawnPoint = new Vector3(10f, 0, 0f);
    private readonly System.Collections.Generic.List<GameObject> spawnedObstacles = new();

    void Update()
    {
        if (gameManager.currentState != Game_Manager.GameState.Playing)
        {
            return;
        }
        time += Time.deltaTime;
        if (time >= reactionDelay) 
        {
            PipeSpawner();
            time = 0f;
        }        
    }
    void PipeSpawner()
    {
        float gapY = Random.Range(minGapY, maxGapY);
        Vector3 randomSpawnY = new Vector3(spawnPoint.x, gapY, spawnPoint.z);
        GameObject obstacle = Instantiate(pipe, randomSpawnY, Quaternion.identity);
        Instantiate(platform, spawnPoint, Quaternion.identity);

        spawnedObstacles.Add(obstacle);

        Obstacle_Movement movement = obstacle.GetComponent<Obstacle_Movement>();
        movement.gameManager = gameManager;
        Obstacle_Movement move = platform.GetComponent<Obstacle_Movement>();
        move.gameManager = gameManager;
    }
    public void ClearObstacles()
    {
        foreach (GameObject obstacle in spawnedObstacles)
        {
            if (obstacle != null)
            {
                Destroy(obstacle);
            }
        }
        spawnedObstacles.Clear();
    }
}
