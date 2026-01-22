using UnityEngine;

public class PlayerConstraints : MonoBehaviour
{
    public Camera mainCamera;
    public BoxCollider2D boxCollider;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        Vector3 camPos = mainCamera.transform.position;
        Vector2 extents = boxCollider.bounds.extents;

        float minX = camPos.x - camWidth + extents.x;
        float maxX = camPos.x + camWidth - extents.x;
        float minY = camPos.y - camHeight + extents.y;
        float maxY = camPos.y + camHeight - extents.y;

        Vector2 pos = rb.position;
        Vector2 velocity = rb.linearVelocity;

        // X axis
        if (pos.x <= minX && velocity.x < 0f)
        {
            velocity.x = 0f;
            pos.x = minX;
        }
        else if (pos.x >= maxX && velocity.x > 0f)
        {
            velocity.x = 0f;
            pos.x = maxX;
        }

        // Y axis
        if (pos.y <= minY && velocity.y < 0f)
        {
            velocity.y = 0f;
            pos.y = minY;
        }
        else if (pos.y >= maxY && velocity.y > 0f)
        {
            velocity.y = 0f;
            pos.y = maxY;
        }

        rb.linearVelocity = velocity;
        rb.position = pos;
    }
}
