using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class EasyScrollView : MonoBehaviour
{
    ScrollRect scrollRect;
    RectTransform contentTransform;
    Vector2 paneSize;

    [SerializeField] float spaceBetweenItems;
    [Space]
    [SerializeField] Vector2Int gridSize = new Vector2Int(1, 999);
    [Space]
    [SerializeField] List<IRevalidate> list = new List<IRevalidate>();
    [Header("Changed In App, Serialized for debug")]
    [SerializeField] Vector2 spacing;
    [SerializeField] Vector2 startPos;
    [SerializeField] bool spacingSet = false;

    void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
        contentTransform = scrollRect.content.GetComponent<RectTransform>();
    }

    void Start()
    {
        StartCoroutine(FirstRefresh());
    }

    public void AddItemBottom(GameObject prefab)
    {
        if (!spacingSet)
        {
            RectTransform rTransform = prefab.GetComponent<RectTransform>();
            spacing = rTransform.sizeDelta + new Vector2(spaceBetweenItems, spaceBetweenItems);
            spacingSet = true;

            //startPos = new Vector2(rTransform.position.x/2f, rTransform.position.y / 2f);
        }

        prefab.transform.SetParent(contentTransform);
        prefab.transform.localScale = Vector3.one;

        IRevalidate i = prefab.GetComponent<IRevalidate>();
        list.Add(i);
        
        
        gameObject.transform.localScale = Vector3.one;

        Refresh();
    }

    public void Refresh()
    {
        contentTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, spacing.y * gridSize.y);
        contentTransform.localPosition = Vector3.zero;

        for (int i = 0; i < list.Count; i++)
        {
            float xPos = startPos.x + (spacing.x * (i % gridSize.x));
            float yPos = -startPos.y + (-spacing.y * Mathf.FloorToInt(i / gridSize.x));


            list[i].GetGameObject().transform.localPosition = new Vector2(xPos, yPos);
            list[i].Refresh();
        }
    }

    public void Clear()
    {
        for (int i = list.Count - 1; i > -1; i--)
        {
            GameObject g = list[i].GetGameObject();
            list.Remove(list[i]);
            Destroy(g);
        }
    }

    public IRevalidate[] GetList()
    {
        return list.ToArray();
    }

    IEnumerator FirstRefresh()
    {
        yield return new WaitForSeconds(0.1f);
        Refresh();
    }

    public interface IRevalidate{
        public void Refresh();
        public GameObject GetGameObject();
    }
}