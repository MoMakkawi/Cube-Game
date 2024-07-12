using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{


    public int maxHealth = 100;
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
    public void AddHealth(int damage)
    {
        currentHealth += damage;
        UpdateHealthBar();


    }
    void UpdateHealthBar()
    {
        // تحديث تعبئة شريط الصحة بناءً على الصحة الحالية
        healthBarImage.fillAmount = (float)currentHealth / maxHealth;
    }

    void Die()
    {
        Debug.Log("Player Died!");
        Destroy(gameObject);
        // تنفيذ منطق موت اللاعب
    }
}
