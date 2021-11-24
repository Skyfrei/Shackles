using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="effects", menuName = "Crit Chance Effect")]
public class CritChanceScriptableObject : EffectScriptableObject
{
    public string description;

    public override void BattleEffect()
    {   
        Debug.Log("meme");
    }
    public override void NonBattleEffect(){}
}
