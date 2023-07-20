using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public static float TimeRemaining = 10f; // Set the initial countdown time here.
    public Text timerText;

    private void Start()
    {
        // Get the Text component from the UI Text object
        if (timerText == null)
            timerText = GetComponent<Text>();
    }

    private void Update()
    {
        if (TimeRemaining > 0)
        {
            TimeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            timerText.text = "Time : End";
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