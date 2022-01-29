using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelManager : MonoBehaviour
{
    [Serializable]
    public struct Level
    {
        public string sceneName;
        public bool isOpen;
        public bool isCompleted;
        public float bestTime;
    }

    public static LevelManager instance;

    [Header("Level List")]
    public List<Level> levels;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadData();
    }

    public void LoadData()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if (!PlayerPrefs.HasKey($"level-{i}-open")) return;

            Level levelData = levels[i];
            levelData.isOpen = PlayerPrefs.GetInt($"level-{i}-open") == 1? true : false;
            levelData.isCompleted = PlayerPrefs.GetInt($"level-{i}-completed") == 1 ? true : false;
            levels[i] = levelData;
        }
    }

    public void SaveData()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            // save open condition
            PlayerPrefs.SetInt($"level-{i}-open", levels[i].isOpen ? 1 : 0);

            // save completed condition
            PlayerPrefs.SetInt($"level-{i}-completed", levels[i].isCompleted ? 1 : 0);

            // save best time

        }

    }

    public void SetLevelData(int id, bool isOpen = false, bool isCompleted = false)
    {
        Level newData = levels[id];
        newData.isOpen = isOpen;
        newData.isCompleted = isCompleted;
        levels[id] = newData;

        SaveData();
    } 
}

[CustomEditor(typeof(LevelManager))]
public class LevelManagerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelManager level = (LevelManager)target;
        if (GUILayout.Button("Load Data"))
        {
            level.LoadData();
        }

        if (GUILayout.Button("Save Data"))
        {
            level.SaveData();
        }

        if (GUILayout.Button("Delete All"))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Delete save data completed...");
        }
    }
}