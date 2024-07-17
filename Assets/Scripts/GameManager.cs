using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject diePanel;
    PlayerHealth health;
    private int enemyCount;
    CountdownTimer countdownTimer;
    Gun gun;
    void Start()
    {
        gun = FindObjectOfType<Gun>();
        countdownTimer = FindObjectOfType<CountdownTimer>();
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        print(enemyCount);
        health = FindObjectOfType<PlayerHealth>();
        diePanel.SetActive(false); // تأكد من إخفاء لوحة الموت عند بدء اللعبة
    }

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += HandlePlayerDeath;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= HandlePlayerDeath;
    }

    void HandlePlayerDeath()
    {
        health.isDead = true;
        Debug.Log("Game Manager: Player has died. Handle accordingly.");
        diePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResetGameManager()
    {
        health.isDead = false;
        diePanel.SetActive(false); // تأكد من إخفاء لوحة الموت عند إعادة التشغيل
        Time.timeScale = 1; // إعادة تعيين مقياس الوقت عند إعادة ضبط اللعبة
    }
    public void OnEnemyKilled()
    {
        enemyCount--;
        countdownTimer.ChangeValueOfScore();


        if (enemyCount <= 0)
        {
            GameWin();
        }
    }

    public void GameWin()
    {
        SceneManager.LoadScene("Game Win");
    }
}
