using UnityEngine;

public abstract class BaseState<T> : ScriptableObject, IState
{
    protected T stateMachine;

    public void SetStateMachine(T stateMachine) => this.stateMachine = stateMachine;

    public abstract void OnUpdate();

    public abstract void OnEnterState();

    public abstract void OnExitState();
}
