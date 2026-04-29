using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [Header("Damage")]
    public float damageAmount = 10f;

    [Header("Force")]
    public float speed = 10f;
    public float gravityScale = 1f;

    [Header("Life")]
    public float lifeTime = 2f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.gravityScale = gravityScale;

        // ✅ ล็อกให้ลงแนวดิ่ง (ไม่มีแกน X เลย)
        Vector2 direction = Vector2.down;

        rb.AddForce(direction * speed, ForceMode2D.Impulse);

        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats stats = other.GetComponentInParent<PlayerStats>();

            if (stats != null)
            {
                stats.TakeDamage(damageAmount);
                Debug.Log("Enemy ยิงโดน Player! -" + damageAmount);
            }

            Destroy(gameObject);
        }
        else if (!other.isTrigger)
        {
            Destroy(gameObject);
        }
    }
}