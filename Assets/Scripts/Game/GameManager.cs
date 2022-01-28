using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Level Properties")]
    public float gameTime;
    private float currentGameTime;

    [Header("References")]
    public TMP_Text timerText;

    [HideInInspector] public UnityEvent OnPlayerDie = new UnityEvent();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentGameTime = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
    }

    void CountTime()
    {
        if (currentGameTime >= 0)
        {
            currentGameTime -= Time.deltaTime;
            timerText.text = ConvertFloatToTimeSpan(currentGameTime);
        }
    }

    string ConvertFloatToTimeSpan(float _time)
    {
        TimeSpan times = TimeSpan.FromSeconds(_time);
        return string.Format("{0:00}:{1:00}", times.Minutes, times.Seconds);
    }

    public void PlayerDie()
    {
        OnPlayerDie?.Invoke();
    }
}
