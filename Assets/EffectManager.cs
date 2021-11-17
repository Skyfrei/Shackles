using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

[CreateAssetMenu (fileName ="effectManager", menuName ="Effect Manager")]
public abstract class EffectManager : ScriptableObject
{
    [SerializeField]
    public List<EffectScriptableObject> effectSoList;
    public virtual void PreAttack(){}
    public virtual void DuringAttack(){}
    public virtual void PastAttack(){}
}