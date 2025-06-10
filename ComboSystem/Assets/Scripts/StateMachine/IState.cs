using UnityEngine;

public interface IState
{
    void OnUpdate();
    void OnEnterState();
    void OnExitState();
}