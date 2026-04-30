using UnityEngine;

public class ShowUIOnPlayerTouch : MonoBehaviour
{
    public GameObject player;     // ลาก Player มาใส่
    public GameObject uiImage;    // ลาก UI Image มาใส่

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            uiImage.SetActive(true);
        }
    }
}