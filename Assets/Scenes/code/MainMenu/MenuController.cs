using UnityEngine;
using UnityEngine.SceneManagement; // ต้องมีบรรทัดนี้เพื่อเปลี่ยนหน้า

public class MenuController : MonoBehaviour
{
    // ฟังก์ชันสำหรับปุ่ม Play หรือเลือกด่าน
    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // ฟังก์ชันสำหรับปุ่ม Exit
    public void QuitGame()
    {
        Debug.Log("ออกจากเกม!"); // จะเห็นผลตอน Build เป็นไฟล์เกมแล้วเท่านั้น
        Application.Quit();
    }
}