using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.adjust.sdk;

public class AdjustManager : MonoBehaviour
{
    public string id = "qoy21u10cvsw";
    

    public void InitAdjust()
    {
        AdjustConfig adjustConfig = new AdjustConfig(id, AdjustEnvironment.Production,true);
        adjustConfig.setLogLevel(AdjustLogLevel.Info);
        adjustConfig.setSendInBackground(true);
        new GameObject("Adjust").AddComponent<Adjust>();
        Adjust.addSessionCallbackParameter("foo", "bar");
        adjustConfig.setAttributionChangedDelegate((adjustAttribution) =>
        {
            Debug.LogFormat("Adjust Attribution Callback: ", adjustAttribution.trackerName);
        });
        Adjust.start(adjustConfig);
    }
}
