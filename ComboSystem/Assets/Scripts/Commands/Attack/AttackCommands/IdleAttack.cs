using UnityEngine;

[CreateAssetMenu(fileName = "IdleAttack", menuName = "AttackCommands/IdleAttack")]
public class IdleAttack : BaseAttackCommand
{
    public override void Execute(CooldownManager cooldownManager)
    {
        cooldownManager.StartCooldown(attackValues.GetCooldown());
        Debug.Log("Idle attack");
    }
}
