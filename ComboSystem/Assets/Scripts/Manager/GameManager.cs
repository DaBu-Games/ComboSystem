using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private Character character;
    
    private StateMachine _stateMachine;
    private InputManager _inputManager;
    private CooldownManager _cooldownManager;
    private AttackHistory _attackHistory;

    private void Start()
    {
        _stateMachine = new StateMachine();
        _inputManager = new InputManager();
        
        _stateMachine.AddStateChangeListener( (newState) => _inputManager.ChangeState(newState) );
        
        //Transitions 
        _stateMachine.SwitchState( new IdleState(this) );
        
        //Input bindings
        foreach (Attack attack in character.GetAllAttacks())
        {
            ICommand command = attack.GetAttackCommand(); 
            command.SetValues(attack.GetAttackValues());
            _inputManager.AddInputBinding(attack.GetState(), attack.GetAttackType(), command);
        }
    }

    public void OnNormalAttackInput()
    {
        if(!_cooldownManager.IsOnCooldown())
            HandleAttack(AttackType.normale);
    }

    public void OnSpecialAttackInput()
    {
        if(!_cooldownManager.IsOnCooldown())
            HandleAttack(AttackType.speciale);
    }

    private void HandleAttack(AttackType attackType)
    {
        ICommand attack = _inputManager.GetInputBinding(attackType); 
        attack.Execute(_cooldownManager);
        _attackHistory.AddAttack(_stateMachine.GetCurrentState(), attackType);
    }
}
