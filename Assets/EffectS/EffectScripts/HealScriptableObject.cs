using UnityEngine;

[CreateAssetMenu(fileName ="effects", menuName = "Heal Effect")]
public class HealScriptableObject : EffectScriptableObject
{
    public string description;
    
    public override void BattleEffect(Character player, Enemy enemy, params float[] number){}
    public override void NonBattleEffect(Character player)
    {
        //Actual heal
    }
    public void PotionEffect(Character player)
    {
        player.HP += 20;
    }
}
