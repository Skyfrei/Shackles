using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "player", menuName = "Player")]
public class PlayerScriptableObject : ScriptableObject
{
    // Start is called before the first frame update

    public float attack;
    public float defense;
    public float health;
    public SpriteRenderer artwork;
    void Start()
    {

    }
}
