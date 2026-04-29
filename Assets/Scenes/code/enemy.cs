using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHit = 3;
    private int currentHit = 0;

    public void TakeHit()
    {
        currentHit++;

        if (currentHit >= maxHit)
        {
            Destroy(gameObject);
        }
    }
}