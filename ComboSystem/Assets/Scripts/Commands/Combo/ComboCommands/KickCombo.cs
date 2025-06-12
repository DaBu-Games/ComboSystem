using UnityEngine;

[CreateAssetMenu(fileName = "KickCombo", menuName = "ComboCommands/KickCombo")]
public class KickCombo : BaseComboCommand
{
    public override void Execute(CooldownManager cooldownManager, Animator animator)
    {
        cooldownManager.StartCooldown(attackValues.GetCooldown());
        animator.Play(attackValues.GetAnimation().name);
    }
}