using UnityEngine;
using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class UniVersionManager
{

    [DllImport("__Internal")]
    private static extern string GetVersionName_();

    public static string GetVersion ()
    {
#if UNITY_EDITOR
        return PlayerSettings.bundleVersion;
#elif UNITY_IOS
        return GetVersionName_();
#elif UNITY_ANDROID
        AndroidJavaClass    unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject ajo = new AndroidJavaObject("jp.ne.donuts.packageinfo.PackageInfo");
        AndroidJavaObject context = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity").Call<AndroidJavaObject>("getApplicationContext");
        return ajo.Call<string>("GetVersionName", context);
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
