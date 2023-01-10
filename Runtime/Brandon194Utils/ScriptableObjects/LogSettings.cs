using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Log Settings", menuName = "Brandon194 Utils/Log Settings")]
public class LogSettings : BemScriptableObject
{
    public bool showLogs = true;
    public Color prefixColor = Color.white;
    public string hexColor
    {
        get
        {
            return "#" + ColorUtility.ToHtmlStringRGB(prefixColor);
        }
    }
}
