using System;
using UnityEngine;



[CreateAssetMenu(fileName ="effects", menuName = "Effect")]
public abstract class EffectScriptableObject : ScriptableObject
{
    public virtual string Description{get; set; }
    public abstract void BattleEffect(params float[] number); 
    public abstract void NonBattleEffect(Character player); 
}

