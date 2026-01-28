using UnityEngine;

public class FinishlineMoveDown : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // velocity for finishline in fixed update to ensure consistent movement
    void FixedUpdate()
    {
        rb.linearVelocity = Vector2.down * speed;
    }
}
