using GameAnalyticsSDK;
using GameAnalyticsSDK.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Game Started");

    }
    private void OnApplicationQuit()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Game Finished");
    }
}
