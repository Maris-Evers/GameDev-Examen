using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 input;

    public GameManagerScript gameManager;
    private bool isGameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Makes diagonal speed same as vertical/horizontal speed
        input.Normalize();
    }

    // Fixed update called at fixed interval standard 50x per second
    private void FixedUpdate()
    {
        rb.linearVelocity = input * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            isGameOver = true;
            gameManager.GameOver();
            Debug.Log("Game Over!");
        }
    }

}
