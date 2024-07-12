using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;
    public Image healthBarImage;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
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
        Debug.Log("Enemy Died!");
        // تنفيذ منطق موت العدو
        Destroy(gameObject); // تدمير العدو بعد موته
    }
}
