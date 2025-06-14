using UnityEngine;

[CreateAssetMenu(fileName = "PunchCombo", menuName = "ComboCommands/PunchCombo")]
public class PunchCombo : BaseComboCommand
{
    public override void Execute(CooldownManager cooldownManager, Animator animator, RayCastManager rayCastManager)
    {
        cooldownManager.StartCooldown(attackValues.GetCooldown());
        rayCastManager.Raycast(attackValues.GetRange(), attackValues.GetDamage());
        animator.Play(attackValues.GetAnimation().name);
    }
}
