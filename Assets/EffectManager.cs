using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="effectManager", menuName ="Effect Manager")]
public class EffectManager : ScriptableObject
{
    [SerializeField]
    public List<EffectScriptableObject> effectSoList;
}

public interface IEffects{
    void PreAttack();
    void DuringAttack();
    void PastAttack();
}