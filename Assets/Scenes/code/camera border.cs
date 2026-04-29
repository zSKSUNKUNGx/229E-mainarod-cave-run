using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    [Header("Bounds (Empty Objects)")]
    public Transform leftBound;
    public Transform rightBound;

    [Header("Follow Settings")]
    public float smoothSpeed = 5f;
    public float offsetY = 2f;

    private float camHalfWidth;

    void Start()
    {
        Camera cam = Camera.main;
        camHalfWidth = cam.orthographicSize * cam.aspect;
    }

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPos = transform.position;

        float leftLimit = leftBound.position.x + camHalfWidth;
        float rightLimit = rightBound.position.x - camHalfWidth;

        float playerX = player.position.x;

        // 🎯 logic ติดขอบ
        if (playerX > leftLimit && playerX < rightLimit)
        {
            targetPos.x = playerX;
        }
        else if (playerX <= leftLimit)
        {
            targetPos.x = leftLimit;
        }
        else if (playerX >= rightLimit)
        {
            targetPos.x = rightLimit;
        }

        targetPos.y = player.position.y + offsetY;

        // smooth
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
    }
}