using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public new string name;
    public int id;
    public Sprite sprite;

    public void Print()
    {
        Debug.Log(name + ": " + id);
    }
    //Add stats later=
}
