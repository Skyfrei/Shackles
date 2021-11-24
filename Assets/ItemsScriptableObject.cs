using UnityEngine;
using System.Collections.Generic;

public enum itemType 
{
    Weapon,
    Armor,
    Helmet,
    Ring
}
public enum itemRarity
{
    Common,
    Rare,
    Epic,
    Legendary
}

[CreateAssetMenu(fileName = "item", menuName = "Item")]
public class ItemsScriptableObject : ScriptableObject
{
    public string description;
    public Sprite artwork;
    public int cost;
    public string itemName;
    public bool owned;
    public int id;
    public List<int> components;
    public List<EffectScriptableObject> itemEffects; //Could be 0-1-2+
    //Showing the enum in c# inspector
    public itemType itemTypeEnum;
    public itemRarity itemRarityEnum; 
}
