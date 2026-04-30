using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTrigger : MonoBehaviour
{
    [Header("Scene Name")]
    [SerializeField] private string sceneName; // ใส่ชื่อ Scene ตรง ๆ

    [Header("Target (Drag Player Here)")]
    [SerializeField] private GameObject targetPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetPlayer != null && collision.gameObject == targetPlayer)
        {
            if (!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogWarning("ยังไม่ได้ใส่ Scene Name!");
            }
        }
    }
}