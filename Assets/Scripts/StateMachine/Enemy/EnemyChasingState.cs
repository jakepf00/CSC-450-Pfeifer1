using UnityEngine;

public class EnemyChasingState : EnemyBaseState {
    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine) {}
    public override void Enter() {
        _stateMachine.Animator.CrossFadeInFixedTime(MovementBlendTreeHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime) {
        if (!IsInChaseRange()) {
            _stateMachine.SwitchState(new EnemyIdleState(_stateMachine));
            return;
        }
        if (IsInAttackRange()) {
            _stateMachine.SwitchState(new EnemyAttackingState(_stateMachine));
            return;
        }
        MoveTowardsPlayer(deltaTime);
        FacePlayer();
        _stateMachine.Animator.SetFloat(MovementSpeedHash, 1.0f, AnimationDamping, deltaTime);
    }
    public override void Exit() {
        _stateMachine.NavMeshAgent.velocity = Vector3.zero;
    }
    void MoveTowardsPlayer(float deltaTime) {
        if (_stateMachine.NavMeshAgent.isOnNavMesh) {
            _stateMachine.NavMeshAgent.destination = _stateMachine.Player.transform.position;
            Move(_stateMachine.NavMeshAgent.desiredVelocity.normalized * _stateMachine.MovementSpeed, deltaTime);
        }
        _stateMachine.NavMeshAgent.velocity = _stateMachine.CharacterController.velocity;
    }
}