using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    public float damageAmount = 10f; // ตั้งค่าดาเมจใน Inspector ได้เลย

    // ฟังก์ชันนี้จะทำงานอัตโนมัติเมื่อมี Collider อื่น (ตัวละคร) เข้ามาในระยะ Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // เช็คว่าคนที่โดนคือ Player ใช่ไหม? (เช็คด้วย Tag)
        if (other.CompareTag("Player"))
        {
            // พยายามหา Script PlayerStats จากตัวละคร
            PlayerStats stats = other.GetComponent<PlayerStats>();

            // ถ้าเจอ Script นั้น ให้สั่งเลือดลด
            if (stats != null)
            {
                stats.TakeDamage(damageAmount);
                Debug.Log("โดนกับดักแล้ว! เลือดลดไป " + damageAmount);
            }
        }
    }
}