using UnityEngine;

public class EnemyMoveDown : MonoBehaviour
{
    public float speed;
    public float yDestroyLow = -6f;
    private float yDestroyHigh = 15f;
    private float xDestroy = 13f;
    private float rotationSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        speed = Random.Range(2, 5);
        rotationSpeed = Random.Range(-100, 100);

        // velocity set in start function to make bouncy collisions work properly
        rb.angularVelocity = rotationSpeed;
        rb.linearVelocity = Vector2.down * speed;
    }

    void Update()
    {
        if (transform.position.y < yDestroyLow || transform.position.y > yDestroyHigh || transform.position.x > xDestroy || transform.position.x < -xDestroy)
        {
            Destroy(gameObject);
        }
    }
}
