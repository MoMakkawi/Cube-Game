using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;
    public Image healthBarImage;
    GameManager gameManager;
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        healthBarImage.fillAmount = (float)currentHealth / maxHealth;
    }

    void Die()
    {
        gameManager.OnEnemyKilled();
        Debug.Log("Enemy Died!");
        // تنفيذ منطق موت العدو
        Destroy(gameObject); // تدمير العدو بعد موته
    }
}
