using System;
using UnityEngine;

[Serializable]
public class AttackValues
{
    [SerializeField]private float damage;
    [SerializeField]private AnimationClip animation;
    [SerializeField]private AttackType attackType;
    [SerializeField]private InterfaceReference<IState> state;
    
    public float GetCooldown() => animation.length;
    public float GetDamage() => damage;
    public AnimationClip GetAnimation() => animation;
    public AttackType GetAttackType() => attackType;
    public IState GetState() => state.Value;
}
