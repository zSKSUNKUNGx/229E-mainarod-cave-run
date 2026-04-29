using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("ยิงกระสุน")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Target")]
    public Transform player; // ลาก Player มาใส่

    [Header("Fire Rate")]
    public float fireRate = 1.5f;
    private float nextFireTime = 0f;

    private void Update()
    {
        

        // ยิงตามเวลา
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}