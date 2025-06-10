using UnityEngine;

public class IdleAttackCommand : ICommand
{
    private AttackValues _values;
    public void SetValues(AttackValues values)
    {
        _values = values;
    }

    public void Execute(CooldownManager cooldownManager)
    {
        cooldownManager.StartCooldown(_values.GetCooldown());
        Debug.Log("Ground atack");
    }
}
