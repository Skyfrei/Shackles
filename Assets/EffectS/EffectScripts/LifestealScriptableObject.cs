using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="effects", menuName = "Lifesteal Effect")]
public class LifestealScriptableObject : EffectScriptableObject
{
    private string description;
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

    public override void BattleEffect(params float[] number)
    {   
        
    }
    public override void NonBattleEffect(Character player){}
}
