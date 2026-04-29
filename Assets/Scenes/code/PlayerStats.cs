using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // ต้องเพิ่มบรรทัดนี้เพื่อใช้คำสั่งเปลี่ยนฉาก

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Slider healthSlider;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        // เช็คว่าเลือดหมดหรือยัง
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("ตายแล้ว!");
        
        // เลือกว่าจะให้เกิดอะไรขึ้น:
        
        // แบบที่ 1: ไปหน้า Scene Game Over (แนะนำ)
        SceneManager.LoadScene("GameOver"); 
        
        // แบบที่ 2: เริ่มด่านเดิมใหม่ทันที
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}