using System;
using UnityEngine;

[Serializable]
public class AttackValues
{
    [SerializeField]private float cooldown;
    [SerializeField]private float damage;
    [SerializeField]private string animation;
    [SerializeField]private AttackType attackType;
    [SerializeField]private InterfaceReference<IState> state;
    
    public float GetCooldown() => cooldown;
    public float GetDamage() => damage;
    public string GetAnimation() => animation;
    public AttackType GetAttackType() => attackType;
    public IState GetState() => state.Value;
}
