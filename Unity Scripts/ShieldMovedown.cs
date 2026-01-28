using UnityEngine;

public class ShieldMovedown : MonoBehaviour
{
    public float speed = 3f;
    public float yDestroy = -6f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // like the fuel the shield isnt affected by bouncy collisions so movement is set in fixedupdate
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
