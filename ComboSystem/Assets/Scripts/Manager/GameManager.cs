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
        
        //Transitions 
        
        //Input bindings
        foreach (Attack attack in character.GetAllAttacks())
        {
            ICommand command = attack.GetAttackCommand(); 
            command.SetValues(attack.GetAttackValues());
            _inputManager.AddInputBinding(attack.GetState(), attack.GetAttackType(), command);
        }
    }
}
