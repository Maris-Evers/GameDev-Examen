using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject fuel;
    public GameObject shield;

    private float spawnRangeX = 8f;
    private float spawnPosY = 7f;

    private float obstacleDelay = 1.5f;
    private float fuelDelay = 9f;
    private float startDelay = 2f;
    private float shieldDelay = 15f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelay, obstacleDelay);
        InvokeRepeating("SpawnRandomObstacle", startDelay + 0.7f, obstacleDelay);

        InvokeRepeating("SpawnFuel", startDelay + 5f, fuelDelay);
        InvokeRepeating("SpawnShield", startDelay + 10f, shieldDelay);
    }

    void SpawnRandomObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.Length);

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, 0);

        Instantiate(obstacles[randomIndex], spawnPos, transform.rotation);
    }

    void SpawnFuel()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, 0);

        Instantiate(fuel, spawnPos, transform.rotation);
    }

    void SpawnShield()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, 0);

        Instantiate(shield, spawnPos, transform.rotation);
    }
}
