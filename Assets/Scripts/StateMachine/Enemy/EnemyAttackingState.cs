using UnityEngine;

public class EnemyAttackingState : EnemyBaseState {
    #region Animator Hash Data
    readonly int AttackHash = Animator.StringToHash("Punch");
    #endregion
    public EnemyAttackingState(EnemyStateMachine stateMachine) : base(stateMachine) {}
    public override void Enter() {
        _stateMachine.Weapon.SetAttackData(_stateMachine.AttackDamage, _stateMachine.AttackKnockback);
        _stateMachine.Animator.CrossFadeInFixedTime(AttackHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime) {
        if (GetNormalizedTime(_stateMachine.Animator) >= 1.0f) {
            _stateMachine.SwitchState(new EnemyChasingState(_stateMachine));
            return;
        }
        FacePlayer();
    }
    public override void Exit() {}
}