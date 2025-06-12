using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "AttackCommands/BasicAttackCommand")]
public class BasicAttackCommand : BaseAttackCommand
{
    public override void Execute(CooldownManager cooldownManager, Animator animator, RayCastManager rayCastManager)
    {
        cooldownManager.StartCooldown(attackValues.GetCooldown());
        rayCastManager.Raycast(attackValues.GetRange(), attackValues.GetDamage());
        animator.Play(attackValues.GetAnimation().name);
    }
}
