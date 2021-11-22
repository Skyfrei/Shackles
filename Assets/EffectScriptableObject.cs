using System;
using UnityEngine;

public interface IEffect
{
    void PastAttack();
}

[CreateAssetMenu(fileName ="effects", menuName = "Effect")]
public class EffectScriptableObject : ScriptableObject
{
    public virtual string Description{get; set; }
}