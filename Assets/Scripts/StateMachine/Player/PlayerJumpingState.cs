using UnityEngine;

public class PlayerJumpingState : PlayerBaseState {
    #region Animator Hash Data
    readonly int JumpHash = Animator.StringToHash("Jump");
    #endregion
    #region Other Data
    Vector3 _momentum;
    #endregion

    public PlayerJumpingState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter() {
        _stateMachine.ForceReceiver.AddJumpForce(_stateMachine.JumpForce);
        _momentum = _stateMachine.CharacterController.velocity;
        _momentum.y = 0.0f;
        _stateMachine.Animator.CrossFadeInFixedTime(JumpHash, 0.0f);
    }

    public override void Exit() {}

    public override void Tick(float deltaTime) {
        Move(_momentum, deltaTime);
        FaceTarget();
        if (_stateMachine.CharacterController.velocity.y <= 0.0f) {
            _stateMachine.SwitchState(new PlayerFallingState(_stateMachine));
            return;
        }
    }
}