using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BaseComboCommand : ScriptableObject, IComboCommand
{
    [SerializeField]protected List<InterfaceReference<IAttackCommand>> attackCommands = new List<InterfaceReference<IAttackCommand>>();
    [SerializeField]protected AttackValues attackValues; 
    public AttackValues GetAttackValues() => attackValues; 
    public List<IAttackCommand> GetAttackCommands() =>  attackCommands.Select(x => x.Value).ToList();
    public abstract void Execute(CooldownManager cooldownManager); 
}
