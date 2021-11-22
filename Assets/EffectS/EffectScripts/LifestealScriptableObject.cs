using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="effects", menuName = "Lifesteal Effect")]
public class LifestealScriptableObject : EffectScriptableObject, IEffect
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
    
    public void PastAttack()
    {   
        Debug.Log("meme");
    }
}
