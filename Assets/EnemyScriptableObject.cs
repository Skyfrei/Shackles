using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public new string name;
    public bool fought;
    public Sprite sprite;
    public Vector2 position;

    public void Print()
    {
        Debug.Log(name + ": " + fought);
    }

    //Add stats later

}
