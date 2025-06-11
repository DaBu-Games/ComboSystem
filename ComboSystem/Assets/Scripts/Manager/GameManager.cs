using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField]private Character character;
    
    [Header("States")]
    [SerializeField]private IdleState idleState;
    
    private InputManager _inputManager;
    private CooldownManager _cooldownManager;
    private AttackHistory _attackHistory;
    private StateMachine _stateMachine;

    private void Start()
    {
        //Input bindings
        _inputManager = new InputManager();
        foreach (IAttackCommand command in character.GetAttackCommands())
        {
            AttackValues attackValues = command.GetAttackValues();
            _inputManager.AddInputBinding(attackValues.GetState(), attackValues.GetAttackType(), command);
        }
        
        _cooldownManager = new CooldownManager();
        _attackHistory = new AttackHistory(character); 
        
        // state machine set up
        _stateMachine = new StateMachine();
        _stateMachine.AddStateChangeListener( (newState) => _inputManager.ChangeState(newState) );
        
        //Transitions 
        _stateMachine.SwitchState(idleState);
    }

    public void OnNormalAttackInput(InputAction.CallbackContext context)
    {
        OnAttackInput(context, AttackType.normale);
    }

    public void OnSpecialAttackInput(InputAction.CallbackContext context)
    {
        OnAttackInput(context, AttackType.speciale);
    }

    private void OnAttackInput(InputAction.CallbackContext context, AttackType type)
    {
        if (context.performed && !_cooldownManager.IsOnCooldown())
            HandleAttack(type);
    }

    private void HandleAttack(AttackType attackType)
    {
        IAttackCommand attack = _inputManager.GetInputBinding(attackType);
        _attackHistory.AddAttack(attack);
        
        IComboCommand comboAttack = _attackHistory.CheckForCombo();
        attack = comboAttack ?? attack;
        
        attack.Execute(_cooldownManager);
    }
}
