using UnityEngine;

public class EnemyMoveDown : MonoBehaviour
{
    public float speed;
    public float yDestroy = -6f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        speed = Random.Range(2, 5);
    }

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
