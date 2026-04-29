using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 10f;
    public float gravityScale = 1f;

    [Header("Life")]
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
        // ตั้งค่าแรงโน้มถ่วง
        rb.gravityScale = gravityScale;

        // ยิงเฉียง
        Vector2 shootDirection = new Vector2(dir, 0.5f);
        rb.AddForce(shootDirection.normalized * speed, ForceMode2D.Impulse);

        // กันกระสุนหายช้าเกิน
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ❌ ถ้าโดน Player → ไม่ต้องทำอะไร
        if (other.CompareTag("Player"))
        {
            return;
        }

        // ✅ ถ้าโดน Enemy
        if (other.CompareTag("Enemy"))
        {
            // พยายามหาสคริปต์ Enemy (ถ้ามี)
            var enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeHit();
            }

            // 💥 โดน Enemy แล้วหาย
            Destroy(gameObject);
            return;
        }

        // 💥 ชนอย่างอื่น (พื้น, กำแพง ฯลฯ) → หาย
        Destroy(gameObject);
    }
}