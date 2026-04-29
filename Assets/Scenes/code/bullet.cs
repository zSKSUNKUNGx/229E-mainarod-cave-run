using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;

    private int dir = 1;
    private Rigidbody2D rb;

    public void SetDirection(int direction)
    {
        dir = direction;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // กันพลาด
        if (rb == null) rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0;
        rb.linearVelocity = Vector2.zero;

        rb.linearVelocity = new Vector2(dir * speed, 0f);

        Destroy(gameObject, lifeTime);
    }
}