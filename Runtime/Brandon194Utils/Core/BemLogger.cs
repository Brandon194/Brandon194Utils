using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class BemLogger
{

    public static void Log(string prefix, Color color, string message, bool loggerEnable = true, Object sender = null)
    {
        if (loggerEnable)
        {
            string hexColor =  "#" + ColorUtility.ToHtmlStringRGB(color);

            if (sender == null)
                Debug.Log($"<color={hexColor}><b>{prefix}</b></color>: {message}");
            else
                Debug.Log($"<color={hexColor}><b>{prefix}</b></color>: {message}", sender);
        }
    }

    public static void Log(LogSettings logSettings, object message, Object sender = null)
    {
        if (logSettings.showLogs)
        {
            if (sender == null)
                Debug.Log($"<color={logSettings.hexColor}><b>{logSettings.name}</b></color>: {message}");
            else
                Debug.Log($"<color={logSettings.hexColor}><b>{logSettings.name}</b></color>: {message}", sender);
        }
    }

    public static void LogWarning(string prefix, Color color, string message, bool loggerEnable = true, Object sender = null)
    {
        if (loggerEnable)
        {
            string hexColor = "#" + ColorUtility.ToHtmlStringRGB(color);

            if (sender == null)
                Debug.LogWarning($"<color={hexColor}><b>{prefix}</b></color>: {message}");
            else
                Debug.LogWarning($"<color={hexColor}><b>{prefix}</b></color>: {message}", sender);
        }
    }
    public static void LogWarning(LogSettings logSettings, object message, Object sender = null)
    {
        if (logSettings.showLogs)
        {
            if (sender == null)
                Debug.LogWarning($"<color={logSettings.hexColor}><b>{logSettings.name}</b></color>: {message}");
            else
                Debug.LogWarning($"<color={logSettings.hexColor}><b>{logSettings.name}</b></color>: {message}", sender);
        }
    }

    public static void LogError(string prefix, Color color, string message, bool loggerEnable = true, Object sender = null)
    {
        if (loggerEnable)
        {
            string hexColor = "#" + ColorUtility.ToHtmlStringRGB(color);

            if (sender == null)
                Debug.LogError($"<color={hexColor}><b>{prefix}</b></color>: {message}");
            else
                Debug.LogError($"<color={hexColor}><b>{prefix}</b></color>: {message}", sender);
        }
    }
    public static void LogError(LogSettings logSettings, object message, Object sender = null)
    {
        if (logSettings.showLogs)
        {
            if (sender == null)
                Debug.LogError($"<color={logSettings.hexColor}><b>{logSettings.name}</b></color>: {message}");
            else
                Debug.LogError($"<color={logSettings.hexColor}><b>{logSettings.name}</b></color>: {message}", sender);
        }
    }
}
