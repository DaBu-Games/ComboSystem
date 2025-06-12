using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    private readonly Dictionary<IState, Dictionary<AttackType, IAttackCommand>> _inputBindings = new(); 
    private Dictionary<AttackType, IAttackCommand> _currentInputBindigs = new();
    private IState _currentState;

    public void AddInputBinding(IState state, AttackType attackType, IAttackCommand attackCommand)
    {
        if (!_inputBindings.ContainsKey(state))
        {
            _inputBindings[state] = new Dictionary<AttackType, IAttackCommand>(); 
        }
        
        _inputBindings[state][attackType] = attackCommand;
    }

    public IAttackCommand GetInputBinding(AttackType type)
    {
        return _currentInputBindigs[type];
    }

    public void ChangeState(IState state)
    {
        if (state == null)
            return;
        
        _currentState = state;
        ChangeCurrentInputBinding(); 
    }

    private void ChangeCurrentInputBinding()
    {
        _currentInputBindigs.Clear();
        
        if (_inputBindings.TryGetValue(_currentState, out Dictionary<AttackType, IAttackCommand> bindings))
        {
            _currentInputBindigs.Clear();
            
            foreach (var binding in bindings)
            {
                _currentInputBindigs[binding.Key] = binding.Value;
            }
        }
    }
}
