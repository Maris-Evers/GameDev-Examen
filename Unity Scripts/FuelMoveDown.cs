using UnityEngine;

public class FuelMoveDown : MonoBehaviour
{
    public float speed = 2f;
    public float yDestroy = -6f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // since fuel doesnt factor bouncing from collisions to not make the game too hard, the movement is set in fixedupdate
    void FixedUpdate()
    {
        rb.linearVelocity = Vector2.down * speed;
    }

    void Update()
    {
        if (transform.position.y < yDestroy)
        {
            Destroy(gameObject);
        }
    }
}
