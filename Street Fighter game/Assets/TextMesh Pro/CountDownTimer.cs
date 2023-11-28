using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Time Settings")]
    public float totalTime = 60.0f; // Total countdown time in seconds
    private float currentTime; // Current time left
    
    private bool isCounting = true;

    private void Start()
    {
         //Initialize the timer
        currentTime = totalTime;
        UpdateTimerText();
    }

    private void Update()
    {
        
        if (isCounting)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                //Timer has reached zero
                currentTime = 0;
                isCounting = false;
                // Need to implement a splash screen or display tound is over
            }

            UpdateTimerText();
        }
    }

    public void StartTimer()
    {
        isCounting = true;
    }

    public void StopTimer()
    {
        isCounting = false;
    }

    public void ResetTimer()
    {
        currentTime = totalTime;
        UpdateTimerText();
        isCounting = false;
    }

    private void UpdateTimerText()
    {
        // Format and update the timer text as minutes and seconds
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
