using UnityEngine;

public class SecureScreen : MonoBehaviour
{
    private const int FLAG_SECURE = 0x2000;

    void Awake()
    {
        ApplySecure(true);
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
            ApplySecure(true);
    }

    void OnApplicationPause(bool pause)
    {
        if (!pause)
            ApplySecure(true);
    }

    public static void ApplySecure(bool enable)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        try
        {
            using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                var window = activity.Call<AndroidJavaObject>("getWindow");

                if (enable)
                {
                    window.Call("addFlags", FLAG_SECURE);
                }
                else
                {
                    window.Call("clearFlags", FLAG_SECURE);
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("Secure flag error: " + e.Message);
        }
#endif
    }
}