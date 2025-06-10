using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
    }
}
