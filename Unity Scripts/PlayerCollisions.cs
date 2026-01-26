using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public bool isGameOver;
    public GameManagerScript gameManager;
    public GameObject shield;

    private void Update()
    {
        if (isGameOver)
        {
            Debug.Log("game over");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle") && !shield.activeInHierarchy)
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            isGameOver = true;
            
            gameManager.GameOver();
        }

        if (other.gameObject.CompareTag("Fuel"))
        {
            Destroy(other.gameObject);

            PlayerFuel playerFuel = GetComponent<PlayerFuel>();
            playerFuel.currentFuel += 25f;
            playerFuel.ResetValues();
        }

        if (other.gameObject.CompareTag("Shieldpowerup"))
        {
            Destroy(other.gameObject);
            shield.SetActive(true);
            Invoke("DisableShield", 5f);
        }
    }

    private void DisableShield()
    {
        shield.SetActive(false);
    }
}
