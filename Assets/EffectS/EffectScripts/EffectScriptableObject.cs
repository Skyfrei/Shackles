using System;
using UnityEngine;



[CreateAssetMenu(fileName ="effects", menuName = "Effect")]
public abstract class EffectScriptableObject : ScriptableObject
{
    public virtual string Description{get; set; }
    public abstract void BattleEffect(Character player, Enemy enemy, params float[] number); 
    public abstract void NonBattleEffect(Units unit); 
}

