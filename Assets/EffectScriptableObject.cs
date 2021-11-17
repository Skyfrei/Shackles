using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="effects", menuName = "Effect")]
public class EffectScriptableObject : EffectManager 
{
    public string description;
    public int cooldown;
}