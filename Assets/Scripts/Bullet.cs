using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public const float EnemyNumber = 4;
    public static float EnemyDestroiedNumber = 0;

    public float life = 3f;
    private void Awake()
    {
        // Get information from the GameObject directly
        string gameObjectName = gameObject.name;
        if (gameObjectName.Contains("Enemy")) 
            Destroy(gameObject, life);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Get information from the GameObject directly
        string gameObjectName = collision.gameObject.name;

        if (gameObjectName.Contains("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            EnemyDestroiedNumber++;
            CountdownTimer.SocreNumber = EnemyDestroiedNumber;

            if (CountdownTimer.SocreNumber == EnemyNumber)
                MainMenu.GameWin();
        }

    }
}
