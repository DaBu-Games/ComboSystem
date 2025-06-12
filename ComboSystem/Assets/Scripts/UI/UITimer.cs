using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITimer : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private float startTime = 30f;
    private float currentTime = 0f;
    private bool startTimer = false;
    private TextMeshProUGUI textField;

    public UITimer(TextMeshProUGUI textField)
    {
        this.textField = textField;
        currentTime = startTime;
    }

    public void StartTimer()
    {
        startTimer = true;
        UpdateTextField();
    }
    
    public bool TimerIsActive() => startTimer;

    public void UpdateTime()
    {
        if (!startTimer)
            return;
        
        currentTime -= Time.deltaTime;
        if (currentTime > 0)
        {
            UpdateTextField();
        }
        else
        {
            startTimer = false;
            currentTime = startTime;
            Notify();
        }
    }

    private void UpdateTextField()
    {
        textField.text = currentTime.ToString("00");
    }
    
    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver observer in _observers)
        {
            observer.Update(this);
        }
    }
}
