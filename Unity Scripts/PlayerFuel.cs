using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerFuel : MonoBehaviour
{
    private float maxFuel = 100f;
    public float currentFuel;
    private float fuelConsumptionRate = 2.5f;
    public Slider fuelSlider;
    public TextMeshProUGUI fuelText;

    bool isGameOver;

    private float countdown = 20f;
    private float timer;
    private float disIncRate;
    private DistanceCalculator distanceCalculator;
    private Player playerController;
    private float playerSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentFuel = maxFuel;

        GameObject player = GameObject.FindWithTag("Player");
        PlayerCollisions playerCollisions = player.GetComponent<PlayerCollisions>();
        isGameOver = playerCollisions.isGameOver;

        timer = countdown;

        GameObject distanceCalc = GameObject.FindWithTag("Distance");
        distanceCalculator = distanceCalc.GetComponent<DistanceCalculator>();
        disIncRate = distanceCalculator.DistanceIncreaseRate;
        
        playerController = player.GetComponent<Player>();
        playerSpeed = playerController.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFuel > 100f)
        {
            currentFuel = 100f;
        }
        currentFuel -= fuelConsumptionRate * Time.deltaTime;

        fuelSlider.value = currentFuel / maxFuel;
        fuelText.text = "Fuel left: " + Mathf.Floor(currentFuel);

        if (currentFuel <= 0 && !isGameOver)
        {
            currentFuel = 0;
            fuelText.text = "Fuel left: " + Mathf.Floor(currentFuel);

            timer -= Time.deltaTime;
            float speedFactor = timer / countdown;


            if (timer > 0f)
            {
                distanceCalculator.DistanceIncreaseRate = disIncRate * speedFactor;
                playerController.speed = playerSpeed * speedFactor;
            }
        }
    }

    public void ResetValues()
    {
        distanceCalculator.DistanceIncreaseRate = disIncRate;
        playerController.speed = playerSpeed;
        timer = countdown;
    }
}
