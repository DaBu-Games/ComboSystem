using UnityEngine;

public abstract class BaseAttackCommand : ScriptableObject, IAttackCommand
{
    [SerializeField]protected AttackValues attackValues; 
    public AttackValues GetAttackValues() => attackValues; 
    public abstract void Execute(CooldownManager cooldownManager); 
}
