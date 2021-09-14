using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField]
    private ItemsScriptableObject itemSO;

    public bool equipped;
    public int cost;
    [SerializeField]
    private string description;
    [SerializeField]
    private Sprite artwork;

    void Start()
    {
        cost = itemSO.cost;
        description = itemSO.description;
        artwork = itemSO.artwork;
    } 
}
