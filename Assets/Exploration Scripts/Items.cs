using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public bool equipped;
    public int id;
    public bool owned;
    
    [SerializeField]
    private string itemName;
    public int cost;
    [SerializeField]
    private string description;
    [SerializeField]
    private Sprite artwork;
    [SerializeField]
    private ItemsScriptableObject itemSO;

    void Start()
    {
        cost = itemSO.cost;
        description = itemSO.description;
        artwork = itemSO.artwork;
        itemName = itemSO.itemName;
        id = itemSO.id;
    } 
}
