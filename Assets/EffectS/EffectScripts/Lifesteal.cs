using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public interface IEffects
{
    void PreAttack();
    void DuringAttack();
    void PastAttack();
}

public class Lifesteal : EffectManager, IEffects
{
    public EffectScriptableObject effObj;    
    public Lifesteal()
    {

    }
    public void PreAttack(){}
    public void DuringAttack(){}
    public void PastAttack(){}
}
