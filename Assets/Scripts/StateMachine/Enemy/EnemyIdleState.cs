using UnityEngine;

public class EnemyIdleState : EnemyBaseState {
    #region Idle Data
    [SerializeField] float _idleWaitTime = 2.0f;
    float _idleTimer = 0.0f;
    #endregion

    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine) {}
    public override void Enter() {
        _idleTimer = _idleWaitTime;
        _stateMachine.Animator.CrossFadeInFixedTime(MovementBlendTreeHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime) {
        _idleTimer -= deltaTime;
        if (_idleTimer <= 0.0f) {
            if (IsInChaseRange()) {
                // Transitioning to EnemyChasingState
                return;
            }
            else {
                // Transitioning to EnemyPatrollingState
                return;
            }
        }
        else {
            Move(deltaTime);
            _stateMachine.Animator.SetFloat(MovementSpeedHash, 0.0f, AnimationDamping, deltaTime);
        }
    }
    public override void Exit() {}
}