using UnityEngine;
using TMPro;

public class DistanceCalculator : MonoBehaviour
{
    private float distance;
    private float totalDistance;
    public float DistanceIncreaseRate = 5f;
    public TextMeshProUGUI distanceText;
    public GameObject finishLine;
    private bool finishLineActive = false;

    // Update is called once per frame
    void Update()
    {
        distance = Time.deltaTime * DistanceIncreaseRate;
        totalDistance += distance;
        
        distanceText.text = "Distance: " + Mathf.Floor(totalDistance) + " LY";

        // Spawns finishline and stops obstacles from spawning when nearing the reqiured distance
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
