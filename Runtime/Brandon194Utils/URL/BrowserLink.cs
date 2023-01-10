using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrowserLink : MonoBehaviour
{
    public static void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
