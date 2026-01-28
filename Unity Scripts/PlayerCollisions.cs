using UnityEngine;
using TMPro;

public class PlayerCollisions : MonoBehaviour
{
    public bool isGameOver;
    public GameManagerScript gameManager;
    public GameObject shield;
    public TextMeshProUGUI deathFlavorText;
    public GameObject explosionParticle;
    public AudioSource audioSource;
    public AudioClip explosionSound;

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
            audioSource.PlayOneShot(explosionSound, 1f);
            Instantiate(explosionParticle, transform.position, transform.rotation);

            deathFlavorText.text = "You crashed into a " + other.gameObject.name + "!";
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

        if (other.gameObject.CompareTag("Finish"))
        {
            gameManager.GameWin();
        }
    }

    private void DisableShield()
    {
        shield.SetActive(false);
    }
}
