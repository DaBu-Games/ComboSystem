using UnityEngine;

public interface ICommand
{
    void SetValues(AttackValues values); 
    void Execute(CooldownManager cooldownManager);
}
