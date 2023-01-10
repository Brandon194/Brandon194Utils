using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScaler : MonoBehaviour
{
    public static SceneScaler instance;
    private void Awake()

    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

    public float scaleScene
    {
        get
        {
            return transform.localScale.x;
        }
        set
        {
            transform.localScale = new Vector3(value, value, value);
            transform.position = Vector3.zero;
        }
    }
}
