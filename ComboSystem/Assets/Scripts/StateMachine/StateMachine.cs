using UnityEngine;
using System;
using System.Collections.Generic;

public class StateMachine
{
    private IState _currentState;
    private Dictionary<Type, IState> _allStates = new Dictionary<Type, IState>();
    private List<Transition> _transitions = new List<Transition>();
    private List<Transition> _currentTransitions = new List<Transition>();
    private event Action<IState> _onStateChange;

    public void OnUpdate()
    {
        foreach (var transition in _currentTransitions) 
        {
           if( transition.CheckCondition())
               SwitchState( transition.toState );
        }
        
        _currentState?.OnUpdate();
    }

    public void AddState(IState state)
    {
        _allStates.TryAdd(state.GetType(), state);
    }

    public void RemoveState(Type type) 
    {
        if ( _allStates.ContainsKey(type) )
            _allStates.Remove(type);
    }

    public void SwitchState(IState state)
    {
        if(state == null || state.GetType() == _currentState?.GetType())
            return;
        
        _currentState?.OnExitState();
        _currentState = state;
        _currentTransitions = _transitions.FindAll(x => x.fromState == _currentState || x.fromState == null);
        _currentState.OnEnterState();

        _onStateChange?.Invoke(_currentState); 

        Debug.Log(_currentState.ToString());
    }

    public void AddTransition(Transition transition)
    {
        _transitions.Add(transition);
    }

    public void AddStateChangeListener(Action<IState> handler)
    {
        _onStateChange += handler;
    }

    public void RemoveStateChangeListener(Action<IState> handler)
    {
        _onStateChange -= handler;
    }
    
    public IState GetCurrentState() => _currentState;
}
