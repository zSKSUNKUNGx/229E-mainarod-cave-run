using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ห้ามลืมบรรทัดนี้เด็ดขาด ไม่งั้นใช้ Slider ไม่ได้

public class PlayerStats : MonoBehaviour
{
    [Header("Health Settings")]
    public Slider healthSlider;
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Energy Settings")]
    public Slider energySlider;
    public float maxEnergy = 100f;
    private float currentEnergy;

    void Start()
    {
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;

        // ตั้งค่าให้ Slider เต็มตั้งแต่เริ่ม
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        energySlider.maxValue = maxEnergy;
        energySlider.value = currentEnergy;
    }

    // ฟังก์ชันนี้ไว้เรียกจากสคริปต์อื่น เช่น ตอนโดนยิง
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
    }

    // ฟังก์ชันนี้ไว้เรียกเวลาใช้พลังงาน
    public void UseEnergy(float amount)
    {
        currentEnergy -= amount;
        energySlider.value = currentEnergy;
    }
    void Update()
{
    // กดปุ่ม H เพื่อลดเลือด
    if (Input.GetKeyDown(KeyCode.H))
    {
        TakeDamage(10);
    }
    // กดปุ่ม E เพื่อลดพลังงาน
    if (Input.GetKeyDown(KeyCode.E))
    {
        UseEnergy(10);
    }
}
}