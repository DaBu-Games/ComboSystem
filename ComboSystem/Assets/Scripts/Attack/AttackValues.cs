using UnityEngine;

public class AttackValues
{
    private float _cooldown;
    private AttackType _attackType;
    private float _damage;
    private string _animation;

    public AttackValues(float cooldown, AttackType attackType, float damage, string animation)
    {
        _cooldown = cooldown;
        _attackType = attackType;
        _damage = damage;
        _animation = animation;
    }
    
    public float GetCooldown() => _cooldown;
    public AttackType GetAttackType() => _attackType;
    public float GetDamage() => _damage;
    public string GetAnimation() => _animation;
}
