using System;
using UnityEngine;



[CreateAssetMenu(fileName ="effects", menuName = "Effect")]
public class EffectScriptableObject : ScriptableObject
{
    public virtual string Description{get; set; }
}

