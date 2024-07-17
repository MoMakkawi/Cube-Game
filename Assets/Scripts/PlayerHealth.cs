using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{


    public int maxHealth = 100;
    private int currentHealth;
    public Image healthBarImage;
    public bool isDead = false;
    public static Action OnPlayerDeath;
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

    public void Die()
    {
        Time.timeScale = 0;
        isDead = true;
        OnPlayerDeath?.Invoke();


    }
    public bool IsDead()
    {
        return isDead;
    }
}
