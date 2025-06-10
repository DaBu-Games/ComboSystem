using System;
using UnityEngine;

[Serializable]
public class AttackValues
{
    private float _cooldown;
    private float _damage;
    private string _animation;

    public AttackValues(float cooldown, float damage, string animation)
    {
        _cooldown = cooldown;
        _damage = damage;
        _animation = animation;
    }
    
    public float GetCooldown() => _cooldown;
    public float GetDamage() => _damage;
    public string GetAnimation() => _animation;
}
