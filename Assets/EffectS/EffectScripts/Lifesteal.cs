using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Lifesteal : EffectManager
{
    public Lifesteal()
    {
        effectSoList[0].PreAttack();
    }
    public override void PreAttack(){Console.WriteLine("Sup mate");}
    public override void DuringAttack(){}
    public override void PastAttack(){}
}
