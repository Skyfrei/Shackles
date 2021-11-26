using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool equipped;
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
            equipped = true;
            owned = itemSO.owned;
        }
    }
}
