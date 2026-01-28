using UnityEngine;
using TMPro;

public class DistanceCalculator : MonoBehaviour
{
    public float time;
    private float distance;
    private float totalDistance;
    public TextMeshProUGUI distanceText;
    public GameManagerScript gameManager;
    public float DistanceIncreaseRate = 5f;
    public GameObject finishLine;
    private bool finishLineActive = false;
    public GameObject spawnManager;

    // Update is called once per frame
    void Update()
    {
        distance = Time.deltaTime * DistanceIncreaseRate;
        totalDistance += distance;
        
        distanceText.text = "Distance: " + Mathf.Floor(totalDistance) + " LY";

        if (totalDistance >= 490f && !finishLineActive)
        {
            GameObject.Find("SpawnManager").GetComponent<SpawnManager>().OnResetOrWin();
            SpawnFinish();
            finishLineActive = true;
        }
    }

    private void SpawnFinish()
    {
        Instantiate(finishLine, new Vector3(0, 10, 0), transform.rotation);
    }
}
