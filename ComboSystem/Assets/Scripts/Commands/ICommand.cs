using UnityEngine;

public interface ICommand
{
    void Execute();
    AttackValues GetAttackValues();
}
