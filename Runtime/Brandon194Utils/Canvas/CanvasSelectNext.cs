using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasSelectNext: MonoBehaviour
{
    [SerializeField] GameObject currentlySelected;
    [SerializeField] List<Selectable> selectables = new List<Selectable>();

    [SerializeField] bool select0OnStart = false;

    private void Start()
    {
        if (select0OnStart) EventSystem.current.SetSelectedGameObject(selectables[0].gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift) && selectables.Count > 0)
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(selectables[0].gameObject);
            }
            else
            {
                
                for (int i = 0; i < selectables.Count; i++)
                {
                    if (selectables[i].gameObject == EventSystem.current.currentSelectedGameObject)
                    {
                        Debug.Log((i - 1 + selectables.Count) % selectables.Count);
                        EventSystem.current.SetSelectedGameObject(selectables[(-1 + selectables.Count) % selectables.Count].gameObject);

                        if (selectables[(selectables.Count - 2) % selectables.Count].GetType() == typeof(TMPro.TMP_Dropdown))
                        {
                            ((TMPro.TMP_Dropdown)selectables[(selectables.Count - 2) % selectables.Count]).Show();
                        }

                        break;
                    }
                }
            }

        }
        else if (Input.GetKeyDown(KeyCode.Tab) && selectables.Count > 0)
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(selectables[0].gameObject);
            }
            else
            {
                for (int i = 0; i < selectables.Count; i++)
                {
                    if (selectables[i].gameObject == EventSystem.current.currentSelectedGameObject)
                    {
                        EventSystem.current.SetSelectedGameObject(selectables[(i + 1) % selectables.Count].gameObject);

                        if (selectables[(i + 1) % selectables.Count].GetType() == typeof(TMPro.TMP_Dropdown))
                        {
                            ((TMPro.TMP_Dropdown)selectables[(i + 1) % selectables.Count]).Show();
                        }

                        break;
                    }
                }
            }

            currentlySelected = EventSystem.current.currentSelectedGameObject;
        }
    }
}
