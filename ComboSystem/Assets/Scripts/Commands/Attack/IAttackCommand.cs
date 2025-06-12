using UnityEngine;

public interface IAttackCommand
{
    AttackValues GetAttackValues();
    void Execute(CooldownManager cooldownManager, Animator animator);
}
