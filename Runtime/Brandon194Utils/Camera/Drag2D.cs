using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag2D : MonoBehaviour
{
    Camera camera;

    public delegate void DragStart();
    public delegate void DragStop();

    public static DragStart OnDragStart;
    public static DragStop OnDragStop;

    [SerializeField] LayerMask layerMask;
    [Space]
    [SerializeField] GameObject dragging;
    [SerializeField] bool currentlyDragging = false;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 5f, layerMask);

            if (hit == false) return;

            dragging = hit.collider.gameObject;
            currentlyDragging = dragging != null;

            if (currentlyDragging == true)
            {
                //OnDragStart();
            }
        }
        else if (Input.GetButtonUp("Fire1") && currentlyDragging)
        {
            dragging.transform.position = dragging.transform.position + new Vector3(0f, 0f, dragging.transform.parent.position.z);
            
            Vector3 pos = dragging.transform.localPosition;
            pos = new Vector3(pos.x, pos.y, 0f);
            dragging.transform.localPosition = pos;

            dragging = null;
            currentlyDragging = false;
            OnDragStop();
        }

        if (currentlyDragging)
        {
            Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            dragging.transform.position = new Vector3(mousePos.x, mousePos.y, dragging.transform.parent.position.z-1f);
        }
    }
}
