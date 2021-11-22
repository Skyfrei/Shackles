using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="effects", menuName = "Shield Effect")]
public class ShieldScriptableObject : EffectScriptableObject
{
    private string description;
    public int cooldown;
    
    public override string Description
    {
        get
        {
            return description;
        }
        set
        {
            description = "You are able to steal life from your opponent based on how much damage you deal.";
        }
    }

    public void PreAttack()
    {

    }
}