using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Air Control")]
    public float airControlMultiplier = 0.7f;

    [Header("Jump")]
    public float jumpForce = 10f;
    public float jumpBoost = 1.2f;          // 🔥 เพิ่ม/ลดความสูง
    public float jumpUpMultiplier = 2f;     // 🔥 ทำให้ “พุ่งขึ้นไว”
    public float jumpCooldown = 0.5f;
    private float jumpCooldownTimer;

    [Header("Gravity")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [Header("Shoot")]
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.3f;

    private Rigidbody2D rb;
    private float moveInput;

    private int faceDir = 1;
    private float nextFireTime = 0f;

    private Vector3 firePointOriginPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (firePoint != null)
            firePointOriginPos = firePoint.localPosition;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        // ===== จำทิศ =====
        if (moveInput > 0) faceDir = 1;
        else if (moveInput < 0) faceDir = -1;

        // ===== jump cooldown =====
        jumpCooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && jumpCooldownTimer <= 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * jumpBoost);
            jumpCooldownTimer = jumpCooldown;
        }

        // ===== ยิง =====
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

        UpdateFirePoint();
    }

    void FixedUpdate()
    {
        float speed = moveSpeed;

        bool inAir = Mathf.Abs(rb.linearVelocity.y) > 0.01f;
        if (inAir)
            speed *= airControlMultiplier;

        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        ApplyBetterGravity();

        // 🔥 ทำให้ขึ้นไวขึ้น (พุ่งขึ้นทันที ไม่หน่วง)
        if (rb.linearVelocity.y > 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (jumpUpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }

    // ===== ยิง =====
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(faceDir);
    }

    // ===== FirePoint =====
    void UpdateFirePoint()
    {
        if (firePoint == null) return;

        firePoint.localPosition = new Vector3(
            Mathf.Abs(firePointOriginPos.x) * faceDir,
            firePointOriginPos.y,
            firePointOriginPos.z
        );
    }

    // ===== Gravity feel =====
    void ApplyBetterGravity()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }
}