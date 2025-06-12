using UnityEngine;

[CreateAssetMenu(menuName = "States/IdleState")]
public class IdleState : BaseState<GameManager>
{
    public override void OnUpdate()
    {
        
    }

    public override void OnEnterState()
    {
        stateMachine.playerAnimator.Play("Idle");
    }

    public override void OnExitState()
    {
        
    }
}
