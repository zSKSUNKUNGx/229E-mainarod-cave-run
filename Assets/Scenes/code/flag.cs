#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTrigger : MonoBehaviour
{
    [Header("Scene (Drag Here)")]
    [SerializeField] private Object sceneAsset; // ลาก Scene ได้

    [Header("Target (Drag Player Here)")]
    [SerializeField] private GameObject targetPlayer; // ลาก Player มาใส่

    private string sceneName;

    private void Awake()
    {
        if (sceneAsset != null)
        {
            sceneName = sceneAsset.name;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ✅ เช็คแบบลาก GameObject
        if (targetPlayer != null && collision.gameObject == targetPlayer)
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("ยังไม่ได้ใส่ Scene!");
        }
    }
}