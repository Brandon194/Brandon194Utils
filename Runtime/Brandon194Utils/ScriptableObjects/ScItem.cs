using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Brandon194 Utils/Items/Item")]
public class ScItem : BemScriptableObject
{
    public string displayName;
    public string packName = "technicallycrafted";
    public Sprite sprite;
    public int maxStack = 64;
    public ScDictionaryTag[] oreDictionaryTags;
    [Space]
    public int price;
    public int fuelTime;
    [Space]
    public ScItem[] returnedAfterCrafting;
}
