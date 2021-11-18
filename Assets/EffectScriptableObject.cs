using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="effects", menuName = "Effect")]
public class EffectScriptableObject : ScriptableObject 
{
    public virtual string Description{ get; set; }
}

[CreateAssetMenu(fileName ="effects", menuName = "Lifesteal Effect")]
public class LifestealScriptableObject : EffectScriptableObject
{
    public override string Description
    {
        get
        {
            return Description;
        }
        set
        {
            value = "You are able to steal life from your opponent based on how much damage you deal.";
        }
    }
    

    public void PastAttack()
    {   

    }
}

[CreateAssetMenu(fileName ="effects", menuName = "Shield Effect")]
public class ShieldScriptableObject : EffectScriptableObject
{
    public string description;
    public int cooldown;
    
    public void PreAttack()
    {

    }
}

[CreateAssetMenu(fileName ="effects", menuName = "Crit Chance Effect")]
public class CritChanceScriptableObject : EffectScriptableObject
{
    public string description;

    public void PreAttack()
    {

    }
}

[CreateAssetMenu(fileName ="effects", menuName = "Shield Effect")]
public class AttackUpScriptableObject : EffectScriptableObject
{
    public string description;

    public void PreAttack()
    {

    }
}