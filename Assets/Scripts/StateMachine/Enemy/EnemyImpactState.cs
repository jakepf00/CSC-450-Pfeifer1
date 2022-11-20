using UnityEngine;

public class EnemyImpactState : EnemyBaseState {
    #region AnimatorHashData
    readonly int ImpactHash = Animator.StringToHash("Impact");
    [SerializeField] float _impactDuration = 1.0f;
    #endregion
    public EnemyImpactState(EnemyStateMachine stateMachine) : base(stateMachine) {}
    public override void Enter() {
        _stateMachine.Animator.CrossFadeInFixedTime(ImpactHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime) {
        _impactDuration -= deltaTime;
        if (_impactDuration <= 0.0f) {
            _stateMachine.SwitchState(new EnemyIdleState(_stateMachine));
            return;
        }
        Move(deltaTime);
    }
    public override void Exit() {}
}