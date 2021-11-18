using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "item", menuName = "Item")]
public class ItemsScriptableObject : ScriptableObject
{
    public string description;
    public Sprite artwork;
    public int cost;
    public string itemName;
    public int id;
    public List<int> components;
    public EffectManager effect;

    //Showing the enum in c# inspector
    [SerializeField]
    private itemType itemTypeEnum;
    [SerializeField]
    private itemRarity itemRarityEnum;

    public enum itemType 
    {
        Weapon,
        Armor,
        Ring,
        Necklace,
        Shoes,
        Helmet
    }
    public enum itemRarity
    {
        Common,
        Rare,
        Epic,
        Legendary
    }
}
