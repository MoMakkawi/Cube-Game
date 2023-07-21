using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public static float TimeRemaining ; // Set the initial countdown time here.
    public static float BulletRemaining;
    public static float SocreNumber;

    public Text timerText;
    public Text bulletText;
    public Text scoreText;

    private void Start()
    {
        // Get the Text component from the UI Text object
        if (timerText == null)
            timerText = GetComponent<Text>();
        if (bulletText == null)
            bulletText = GetComponent<Text>();

        TimeRemaining = 40f; // Set the initial countdown time he
        SocreNumber = 0f;
    }

    private void Update()
    {
        bulletText.text = "Bullet = " + BulletRemaining.ToString();
        scoreText.text = "Score = " + SocreNumber.ToString();

        if (TimeRemaining > 0)
        {
            TimeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            timerText.text = "Time : End";
            MainMenu.GameOver();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(TimeRemaining / 60);
        int seconds = Mathf.FloorToInt(TimeRemaining % 60);
        string timerString = string.Format("Time : {0:00}:{1:00}", minutes, seconds);
        timerText.text = timerString;
    }
}