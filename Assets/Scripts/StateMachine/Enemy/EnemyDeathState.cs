using UnityEngine;

public class EnemyDeathState : EnemyBaseState {
    #region Animator Hash Data
    readonly int DeathHash = Animator.StringToHash("Death");
    #endregion
    #region Other Data
    const float DestroyTime = 5.0f;
    #endregion
    #region Audio Data
    [SerializeField] int _sfxToPlay = 0;
    #endregion
    public EnemyDeathState(EnemyStateMachine stateMachine) : base(stateMachine) {}
    public override void Enter() {
        _stateMachine.Animator.CrossFadeInFixedTime(DeathHash, CrossFadeDuration);
        GameObject.Destroy(_stateMachine.gameObject, DestroyTime);
        AudioController.Instance.PlaySFX(_sfxToPlay);
    }
    public override void Tick(float deltaTime) {}
    public override void Exit() {}
}