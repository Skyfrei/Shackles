using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    public int cost;
    public bool owned;
    public List<int> components;
    public List<EffectScriptableObject> itemEffects;
    public ItemType ItemType;
    public ItemRarity ItemRarity;

    public string itemName;
    public string description;
    [SerializeField]
    public Sprite artwork;
    public ItemsScriptableObject itemSO;

    void Start()
    {
        if (itemSO != null)
        {
            cost = itemSO.cost;
            description = itemSO.description;
            artwork = itemSO.artwork;
            itemName = itemSO.itemName;
            id = itemSO.id;
            components = itemSO.components;
            itemEffects = itemSO.itemEffects;
            ItemType = itemSO.itemTypeEnum;
            ItemRarity = itemSO.itemRarityEnum;
            owned = itemSO.owned;
        }
    }
    public Item(ItemsScriptableObject itemSo)
    {
        if (itemSo != null)
        {
            this.cost = itemSo.cost;
            this.description = itemSo.description;
            this.artwork = itemSo.artwork;
            this.itemName = itemSo.itemName;
            this.id = itemSo.id;
            this.components = itemSo.components;
            this.itemEffects = itemSo.itemEffects;
            this.ItemType = itemSo.itemTypeEnum;
            this.ItemRarity = itemSo.itemRarityEnum;
            this.owned = itemSo.owned;
        }
    }
}
