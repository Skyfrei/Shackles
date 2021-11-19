using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public bool equipped;
    public int id;
    public int cost;
    public List<int> components;
    public List<EffectScriptableObject> itemEffects;
    public itemType itemTypeEnum;
    public itemRarity itemRarityEnum;

    public string itemName;
    public string description;
    [SerializeField]
    private Sprite artwork;
    public ItemsScriptableObject itemSO;

    void Start()
    {
        this.cost = itemSO.cost;
        this.description = itemSO.description;
        this.artwork = itemSO.artwork;
        this.itemName = itemSO.itemName;
        this.id = itemSO.id;
        this.components = itemSO.components;
        this.itemEffects = itemSO.itemEffects;
        this.itemTypeEnum = itemSO.itemTypeEnum;
        this.itemRarityEnum = itemSO.itemRarityEnum;
        this.equipped = true;
    }
}
