using UnityEngine;

public class PlayerFallingState : PlayerBaseState {
    #region Animator Hash Data
    readonly int FallHash = Animator.StringToHash("Fall");
    #endregion
    #region Other Data
    Vector3 _momentum;
    #endregion

    public PlayerFallingState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter() {
        _momentum = _stateMachine.CharacterController.velocity;
        _momentum.y = 0.0f;
        _stateMachine.Animator.CrossFadeInFixedTime(FallHash, CrossFadeDuration);
    }

    public override void Exit() {}

    public override void Tick(float deltaTime) {
        Move(_momentum, deltaTime);
        FaceTarget();
        if (_stateMachine.CharacterController.isGrounded) {
            _stateMachine.SwitchState(new PlayerMovementState(_stateMachine));
            return;
        }
    }
}