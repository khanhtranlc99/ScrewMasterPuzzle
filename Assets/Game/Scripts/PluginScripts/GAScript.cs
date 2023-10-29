using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using UnityEngine.EventSystems;

public class GAScript : MonoBehaviour
{
    public static GAScript Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
        
        // Vibration.Init();
       
        Init();
    }

    private void Init()
    {
        // GA
        GameAnalytics.Initialize();
    }

    public static void LevelStart(int levelname, int levelAttempts)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, levelname.ToString());
        print("Start::" + levelname);
        //FaceBookScript.instance.LevelStarted(levelname);
    }

    public static void LevelFail(int levelName, int levelAttempts)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, levelName.ToString());
        print("Failed::" + levelName);
        // FaceBookScript.instance.LevelFailed(levelname);
    }

    public static void LevelCompleted(int levelName, int levelAttempts)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, levelName.ToString());
        print("Completed::" + levelName);
        // FaceBookScript.instance.LevelCompleted(levelname);
    }
}