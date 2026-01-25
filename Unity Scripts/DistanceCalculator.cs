using UnityEngine;
using TMPro;

public class DistanceCalculator : MonoBehaviour
{
    public float time;
    private float distance;
    public TextMeshProUGUI distanceText;
    public GameManagerScript gameManager;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        distance = time * 5f;
        distanceText.text = "Distance: " + Mathf.Floor(distance) + " LY";

        if (distance >= 500f)
        {
            gameManager.GameWin();
        }
    }
}
