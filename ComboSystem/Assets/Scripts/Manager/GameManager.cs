using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField]private Character character;
    public Animator playerAnimator;
    
    [Header("States")]
    [SerializeField]private IdleState idleState;
    [SerializeField]private MovingState movingState;
    
    [Header("Raycast")]
    [SerializeField]private LayerMask layerMask;
    
    [Header("UI dmg")]
    [SerializeField]private TextMeshProUGUI dmgCounter;
    
    private InputManager _inputManager;
    private CooldownManager _cooldownManager;
    private AttackHistory _attackHistory;
    private StateMachine _stateMachine;
    private UIDmgCounter _dmgCounter;
    private RayCastManager _rayCastManager;

    private float moveInput = 0f; 

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
        _stateMachine.AddStateChangeListener((newState) => _inputManager.ChangeState(newState));
        
        // state setup
        idleState.SetStateMachine(this); 
        movingState.SetStateMachine(this);
        
        //Transitions 
        _stateMachine.AddTransition(new Transition(idleState, movingState, () => IsMoving()));
        _stateMachine.AddTransition(new Transition(movingState, idleState, () => !IsMoving()));
        
        _stateMachine.SwitchState(idleState);

        _dmgCounter = new UIDmgCounter(dmgCounter);
        _rayCastManager = new RayCastManager(transform.forward, layerMask);
        _rayCastManager.Attach(_dmgCounter);
    }

    private void Update()
    {
        if(!_cooldownManager.IsOnCooldown())
            _stateMachine.OnUpdate();
    }

    public bool IsMoving()
    {
        return math.abs(moveInput) > 0f;
    }

    public bool IsMovingForward()
    {
        return moveInput > 0f;
    }
    
    public void ResetAnimation()
    {
        _stateMachine.GetCurrentState().OnEnterState();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().x;
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
        
        _rayCastManager.SetPosition(this.transform);
        attack.Execute(_cooldownManager, playerAnimator, _rayCastManager);
    }
}
