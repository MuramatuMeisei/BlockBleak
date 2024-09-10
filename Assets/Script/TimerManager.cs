using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private float initialTime = 30f;
    private float leftTime;
    private bool isRunning = false;

    public delegate void TimerEnded();
    public event TimerEnded OnTimerEnd;

    public void StartTimer()
    {
        leftTime = initialTime;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public float GetLeftTime()
    {
        return Mathf.Max(leftTime, 0);
    }

    private void Update()
    {
        if (isRunning)
        {
            leftTime -= Time.deltaTime;

            if (leftTime <= 0)
            {
                StopTimer();
                OnTimerEnd?.Invoke();
            }
        }
    }
}
