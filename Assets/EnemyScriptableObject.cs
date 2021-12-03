using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public new string name;
    public int id;
    public Sprite sprite;
    public int armor;
    public float maxhealth;
    public byte level;
    public float mana;
    public float atk;
    public float critChance = 0.15f;
    public List<ItemsScriptableObject> equipped;

    public void Print()
    {
        Debug.Log(name + ": " + id);
    }
    //Add stats later=
}
