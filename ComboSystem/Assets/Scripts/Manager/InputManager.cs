using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    private readonly Dictionary<IState, Dictionary<AttackType, ICommand>> _inputBindings = new(); 
    private Dictionary<AttackType, ICommand> _currentInputBindigs = new();
    private IState _currentState;

    public void AddInputBinding(IState state, AttackType attackType, ICommand command)
    {
        if (!_inputBindings.ContainsKey(state))
        {
            _inputBindings[state] = new Dictionary<AttackType, ICommand>(); 
        }
        
        _inputBindings[state][attackType] = command;
    }

    public ICommand GetInputBinding(AttackType type)
    {
        return _currentInputBindigs[type];
    }

    public void ChangeState(IState state)
    {
        _currentState = state;
        ChangeCurrentInputBinding(); 
    }

    private void ChangeCurrentInputBinding()
    {
        _currentInputBindigs.Clear();

        if (_currentState != null && _inputBindings.TryGetValue(_currentState, out Dictionary<AttackType, ICommand> bindings))
        {
            _currentInputBindigs = bindings;
        }
    }
}
