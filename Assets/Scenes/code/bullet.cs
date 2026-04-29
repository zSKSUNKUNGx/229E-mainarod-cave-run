using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;
    public float gravityScale = 1f; // เพิ่มตัวแปรคุมแรงโน้มถ่วง

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
        // 1. ตั้งค่าแรงโน้มถ่วง (0 = ยิงตรงเป๊ะ, 1 = ย้อยเหมือนลูกธนู)
        rb.gravityScale = gravityScale; 

        // 2. ใช้แรงส่ง (Impulse) แทนการตั้งค่า Velocity ตรงๆ
        // วิธีนี้จะทำให้กระสุนตอบสนองต่อแรงภายนอกได้ดีกว่า
        Vector2 shootDirection = new Vector2(dir, 0.5f); // 0.5f คือยิงเฉียงขึ้นนิดๆ ให้ดูมีวิถีโค้ง
        rb.AddForce(shootDirection.normalized * speed, ForceMode2D.Impulse);

        Destroy(gameObject, lifeTime);
    }
}