using UnityEngine;


[CreateAssetMenu(fileName = "item", menuName = "Item")]
public class ItemsScriptableObject : ScriptableObject
{
    public string description;
    public Sprite artwork;
    public int cost;
    public bool equipped;

    void Start()
    {
        
    }
}
