using UnityEngine;

[CreateAssetMenu(fileName = "SuperPunchCombo", menuName = "ComboCommands/SuperPunchCombo")]
public class SuperPunchCombo : BaseComboCommand
{
    public override void Execute(CooldownManager cooldownManager)
    {
        cooldownManager.StartCooldown(attackValues.GetCooldown());
        Debug.Log(this.GetType());
    }
}
