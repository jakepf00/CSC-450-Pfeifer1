using UnityEngine;

public class PlayerMovementState : PlayerBaseState {
    public PlayerMovementState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter() {
        _stateMachine.Animator.CrossFadeInFixedTime(MovementBlendTreeHash, CrossFadeDuration);
    }

    public override void Exit() {}

    public override void Tick(float deltaTime) {
        if (_stateMachine.InputReader.MovementValue == Vector2.zero) {
            _stateMachine.Animator.SetFloat(MovementSpeedHash, 0.0f, AnimationDamping, deltaTime);
            Move(deltaTime);
            return;
        }

        Vector3 movement = MoveWithCamera();
        Move(movement * _stateMachine.MovementSpeed, deltaTime);
        Rotate(movement, deltaTime);
        _stateMachine.Animator.SetFloat(MovementSpeedHash, 1.0f, AnimationDamping, deltaTime);
    }

    void Rotate(Vector3 movement, float deltaTime) {
        _stateMachine.transform.rotation = Quaternion.Lerp(
            _stateMachine.transform.rotation, // Rotate from
            Quaternion.LookRotation(movement), // Rotate to
            RotationDamping * deltaTime // Rotation rate/damping
        );
    }

    Vector3 MoveWithCamera() {
        Vector3 forward = _stateMachine.MainCameraTransform.forward;
        Vector3 right = _stateMachine.MainCameraTransform.right;
        forward.y = 0.0f;
        right.y = 0.0f;
        forward.Normalize();
        right.Normalize();
        return forward * _stateMachine.InputReader.MovementValue.y + right * _stateMachine.InputReader.MovementValue.x;
    }
}