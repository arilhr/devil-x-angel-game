using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("References")]
    public Player chara1;
    public Player chara2;

    [Header("Level Properties")]
    public int levelId;
    public float gameTime;
    private float currentGameTime;

    [HideInInspector] public bool isPlaying;
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
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
        CheckWin();
    }

    void CountTime()
    {
        if (!isPlaying) return;

        if (currentGameTime >= 0)
        {
            currentGameTime -= Time.deltaTime;
            UIManager.instance.timerText.text = ConvertFloatToTimeSpan(currentGameTime);
        }

        if (currentGameTime <= 0)
        {
            currentGameTime = 0;
            GameLose();
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

    private void CheckWin()
    {
        if (chara1.isFinished && chara2.isFinished)
        {
            GameWin();
        }
    }

    public void GameWin()
    {
        UIManager.instance.SetWinUI();
        isPlaying = false;

        // set data
        LevelManager.instance.SetLevelData(levelId, true, true);
        
        if (LevelManager.instance.levels.Count - 1 > levelId)
        {
            LevelManager.instance.SetLevelData(levelId + 1, true);
        }
    }

    public void GameLose()
    {
        UIManager.instance.SetLoseUI();
        isPlaying = false;
    }
}

[CustomEditor(typeof(GameManager))]
public class GameManagerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameManager game = (GameManager)target;
        if (GUILayout.Button("Test Win"))
        {
            game.GameWin();
        }

        if (GUILayout.Button("Test Lose"))
        {
            game.GameLose();
        }
    }
}