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

    // Update is called once per frame
    void Update()
    {
        distance = Time.deltaTime * DistanceIncreaseRate;
        totalDistance += distance;
        
        distanceText.text = "Distance: " + Mathf.Floor(totalDistance) + " LY";

        if (totalDistance >= 500f)
        {
            gameManager.GameWin();
        }
    }
}
