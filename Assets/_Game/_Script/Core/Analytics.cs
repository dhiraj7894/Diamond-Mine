using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using Facebook.Unity;
public class Analytics : MonoBehaviour
{
    private void Awake()
    {
        FB.Init();
    }

    private void Start()
    {

        GameAnalytics.Initialize();
    }

    public void AreaExpansionSentData(Transform t)
    {
        GameAnalytics.NewDesignEvent("Area Unlocked : " + t.name);
        print("AREA DATA SENT TO _GAME ANALYTICS_");
    }

    public void Machine(Transform i)
    {
        GameAnalytics.NewDesignEvent("Machines Unlocked : " + i.name);
        print("MACHINE DATA SENT TO _GAME ANALYTICS_");
    }

    public void LevelCompleteProgression(int Level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, (Level + 1).ToString());
        print("LEVEL COMPLETE DATA SENT TO _GAME ANALYTICS_" + (Level + 1));
    }
}
