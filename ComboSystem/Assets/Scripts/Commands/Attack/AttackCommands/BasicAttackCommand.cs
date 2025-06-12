using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "AttackCommands/BasicAttackCommand")]
public class BasicAttackCommand : BaseAttackCommand
{
    public override void Execute(CooldownManager cooldownManager, Animator animator)
    {
        cooldownManager.StartCooldown(attackValues.GetCooldown());
        animator.Play(attackValues.GetAnimation().name);
    }
}
