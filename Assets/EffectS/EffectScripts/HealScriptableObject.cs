using UnityEngine;

[CreateAssetMenu(fileName ="effects", menuName = "Heal Effect")]
public class HealScriptableObject : EffectScriptableObject
{
    public string description;

    public override void BattleEffect(){}
    public override void NonBattleEffect(Character player)
    {
        player.HP += 20;
    }
}
