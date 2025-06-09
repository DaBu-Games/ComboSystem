using UnityEngine;

public abstract class BaseAttackCommand : ICommand
{
    protected AttackValues values;
    
    protected BaseAttackCommand(float cooldown, AttackType attackType, float damage, string animation)
    {
        values = new AttackValues(cooldown, attackType, damage, animation);
    }

    public abstract void Execute();

    public AttackValues GetAttackValues() => values;
}
