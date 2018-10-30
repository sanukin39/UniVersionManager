using UnityEngine;
using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class UniVersionManager
{

#if UNITY_IOS
    [DllImport("__Internal")]
    private static extern string GetVersionName_();
    [DllImport("__Internal")]
    private static extern string GetBuildVersionName_ ();
#endif

    public static string GetVersion ()
    {
#if UNITY_EDITOR
        return PlayerSettings.bundleVersion;
#elif UNITY_IOS
        return GetVersionName_();
#elif UNITY_ANDROID
        AndroidJavaObject ajo = new AndroidJavaObject("net.sanukin.UniVersionManager");
        return ajo.CallStatic<string>("GetVersionName");
#else
        return "0";
#endif
    }

    public static string GetBuildVersion(){
#if UNITY_EDITOR
        return PlayerSettings.bundleVersion;
#elif UNITY_IOS
        return GetBuildVersionName_();
#elif UNITY_ANDROID
        AndroidJavaObject ajo = new AndroidJavaObject("net.sanukin.UniVersionManager");
        return ajo.CallStatic<int>("GetVersionCode").ToString ();
#else
        return "0";
#endif
    }

    public static bool IsNewVersion (string targetVersion)
    {
        var current = new Version(GetVersion());
        var target = new Version(targetVersion);
        return current.CompareTo(target) < 0;
    }
}
