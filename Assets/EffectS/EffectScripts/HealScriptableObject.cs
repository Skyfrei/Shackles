using UnityEngine;

[CreateAssetMenu(fileName ="effects", menuName = "Heal Effect")]
public class HealScriptableObject : EffectScriptableObject
{
    public string description;
    
    public override void BattleEffect(Character player, Enemy enemy, params float[] number){}
    public override void NonBattleEffect(Units unit)
    {
        //Actual heal
    }
    public void PotionEffect(Units unit)
    {
        unit.HP += 20;
    }
}
