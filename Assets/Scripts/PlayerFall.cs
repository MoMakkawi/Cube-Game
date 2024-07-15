using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    public float fallThreshold = -100f; // مستوى السقوط الذي يعتبر موت

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            DieFromFall();
        }
    }

    void DieFromFall()
    {
        PlayerHealth.OnPlayerDeath?.Invoke();
        Debug.Log("Player has fallen to death.");
    }
}
