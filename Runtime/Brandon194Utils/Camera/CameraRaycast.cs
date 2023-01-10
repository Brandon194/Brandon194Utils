using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast
{
    public static GameObject ScreenToWorldPoint2D(Camera camera)
    {
        RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if(hit.collider != null)
        {
            return hit.collider.gameObject;
        } else
        {
            return null;
        }
    }
    public static GameObject ScreenToWorldPoint2D(Camera camera, int layerMask)
    {
        RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, layerMask);
        if (hit.collider != null)
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }
}
