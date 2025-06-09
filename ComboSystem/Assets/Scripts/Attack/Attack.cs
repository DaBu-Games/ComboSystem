using System;
using UnityEngine;

[Serializable]
public class Attack
{
    [SerializeField]private InterfaceReference<IState> state;
    [SerializeField]private AttackType attackType;
    
    public IState GetState() => state.Value;
    public AttackType GetAttackType() => attackType;
}
