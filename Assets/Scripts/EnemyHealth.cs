using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;
    public Image healthBarImage;
    GameManager gameManager;
    enemydie enemydie1;


    void Start()
    {
        enemydie1 = transform.parent.gameObject.GetComponent<enemydie>();
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
        enemydie1.breakblock();
        gameManager.OnEnemyKilled();
        Debug.Log("Enemy Died!");

    }

}
