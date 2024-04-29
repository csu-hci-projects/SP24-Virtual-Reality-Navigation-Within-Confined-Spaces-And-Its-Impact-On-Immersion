using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    public Text stopwatchText; // Reference to the UI Text component to display the stopwatch time
    private float elapsedTime = 0f; // Elapsed time in seconds
    private bool isRunning = false; // Flag to indicate if the stopwatch is running

    void Start()
    {
        // Start the stopwatch automatically when the game begins
        StartStopwatch();
    }

    void Update()
    {
        if (isRunning)
        {
            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Update the UI text to display the elapsed time
            UpdateStopwatchUI();
        }
    }

    void UpdateStopwatchUI()
    {
        // Convert elapsedTime to minutes, seconds, and milliseconds
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 10) % 10);

        // Update the UI text to display the elapsed time
        stopwatchText.text = string.Format("{0:00}:{1:00}:{2:0}", minutes, seconds, milliseconds);
    }

    public void StartStopwatch()
    {
        // Start the stopwatch
        isRunning = true;
    }

    public void StopStopwatch()
    {
        // Stop the stopwatch
        isRunning = false;
    }

    public void ResetStopwatch()
    {
        // Reset the elapsed time
        elapsedTime = 0f;

        // Update the UI text to display the reset time
        UpdateStopwatchUI();
    }
}
