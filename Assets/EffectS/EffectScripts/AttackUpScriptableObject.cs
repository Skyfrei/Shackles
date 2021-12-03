using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="effects", menuName = "Attack Effect")]
public class AttackScriptableObject : EffectScriptableObject
{
    public string description;

    public override void BattleEffect(Character player, Enemy enemy, params float[] number)
    {   
        Debug.Log("meme");
    }
    
    public override void NonBattleEffect(Character player){}
}