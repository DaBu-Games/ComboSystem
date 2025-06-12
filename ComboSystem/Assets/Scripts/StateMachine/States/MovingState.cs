using UnityEngine;

[CreateAssetMenu(menuName = "States/MovingState")]
public class MovingState : BaseState<GameManager>
{
    public override void OnUpdate()
    {
        if (stateMachine.IsMovingForward())
        {
            stateMachine.playerAnimator.Play("WalkingForward");
        }
        else
        {
            stateMachine.playerAnimator.Play("WalkingBack");;
        }
    }

    public override void OnEnterState()
    {
       OnUpdate();
    }

    public override void OnExitState()
    {
        stateMachine.playerAnimator.speed = 1f;
    }
}
