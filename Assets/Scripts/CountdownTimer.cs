using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    private float _timeRemaining; // Set the initial countdown time here.
    private float _bulletRemaining;
    private float _scoreNumber;

    [Header("Components")]
    private Text timerText;
    private Text bulletText;
    private Text scoreText;

    private void Awake()
    {

        timerText = transform.GetChild(0).GetComponent<Text>();
        bulletText = transform.GetChild(1).GetComponent<Text>();
        scoreText = transform.GetChild(2).GetComponent<Text>();
    }
    private void Start()
    {
        _timeRemaining = 70f;
        _scoreNumber = 0f;
        _bulletRemaining = 68;
        UpdateBulletUI();
    }
    public void ReduceBullet()
    {

        _bulletRemaining--;
        UpdateBulletUI();
        if (_bulletRemaining <= 0)
        {
            PlayerHealth.OnPlayerDeath?.Invoke();
        }


    }
    private void UpdateBulletUI()
    {
        bulletText.text = "Bullet : " + _bulletRemaining.ToString();
    }

    private void Update()
    {

        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            timerText.text = "Time : End";
            PlayerHealth.OnPlayerDeath?.Invoke();
        }
    }
    public void ChangeValueOfScore()
    {
        _scoreNumber++;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score : " + _scoreNumber.ToString();
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(_timeRemaining / 60);
        int seconds = Mathf.FloorToInt(_timeRemaining % 60);
        string timerString = string.Format("Time : {0:00}:{1:00}", minutes, seconds);
        timerText.text = timerString.ToString();
    }
}