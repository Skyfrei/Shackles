using System;
using UnityEngine;



[CreateAssetMenu(fileName ="effects", menuName = "Effect")]
public abstract class EffectScriptableObject : ScriptableObject
{
    public virtual string Description{get; set; }
    public abstract void BattleEffect(); 
    public abstract void NonBattleEffect(Character player); 
}

