using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="effects", menuName = "Mana Effect")]
public class ManaScriptableObject : EffectScriptableObject
{
    public string description;
    
    public override void BattleEffect(Character player, Enemy enemy, params float[] number){}
    public override void NonBattleEffect(Units unit)
    {
        //Actual mana regen
    }
    public void ManaPotionEffect(Units unit)
    {
        unit.Mana += 50;
    }
}
