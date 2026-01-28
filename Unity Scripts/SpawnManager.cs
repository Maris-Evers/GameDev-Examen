using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject fuel;
    public GameObject shield;

    private float spawnRangeX = 8f;
    private float spawnPosY = 7f;

    private float obstacleDelay = 0.8f;
    private float fuelDelay = 9f;
    private float startDelay = 2f;
    private float shieldDelay = 15f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelay, obstacleDelay);
        InvokeRepeating("SpawnFuel", startDelay + 5f, fuelDelay);
        InvokeRepeating("SpawnShield", startDelay + 10f, shieldDelay);
    }

    void SpawnRandomObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, 0);

        GameObject newTarget = Instantiate(obstacles[randomIndex], spawnPos, transform.rotation);
        newTarget.name = newTarget.name.Replace("(Clone)","").Trim();
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

    public void OnResetOrWin()
    {
        CancelInvoke("SpawnRandomObstacle");
        CancelInvoke("SpawnFuel");
        CancelInvoke("SpawnShield");
    }
}
