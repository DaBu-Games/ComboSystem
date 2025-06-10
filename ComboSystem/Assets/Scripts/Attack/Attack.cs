using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Combat/Attack")]
public class Attack : ScriptableObject
{
    [SerializeField]private InterfaceReference<IState> state;
    [SerializeField]private InterfaceReference<ICommand> attackCommand;
    [SerializeField]private AttackType attackType;
    [SerializeField]private AttackValues attackValues;
    
    public IState GetState() => state.Value;
    public ICommand GetAttackCommand() => attackCommand.Value;
    public AttackType GetAttackType() => attackType;
    public AttackValues GetAttackValues() => attackValues; 
}
