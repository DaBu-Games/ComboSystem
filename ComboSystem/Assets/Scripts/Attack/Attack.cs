using System;
using UnityEngine;

[Serializable]
public class Attack
{
    [SerializeField]private InterfaceReference<IState> state;
    [SerializeField]private AttackType attackType;

    public Attack(IState state, AttackType attackType)
    {
        this.state.Value = state;
        this.attackType = attackType;
    }
    
    public IState GetState() => state.Value;
    public AttackType GetAttackType() => attackType;
}
