using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject fuel;

    private float spawnRangeX = 8f;
    private float spawnPosY = 7f;

    private float obstacleDelay = 1f;
    private float fuelDelay = 10f;
    private float startDelay = 2f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelay, obstacleDelay);
        InvokeRepeating("SpawnRandomObstacle", startDelay + 0.5f, obstacleDelay);
    }

    void SpawnRandomObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.Length);

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, 0);

        Instantiate(obstacles[randomIndex], spawnPos, transform.rotation);
    }
}
