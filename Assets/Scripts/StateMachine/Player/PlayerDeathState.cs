using UnityEngine;

public class PlayerDeathState : PlayerBaseState {
    #region Animator Hash Data
    readonly int DeathHash = Animator.StringToHash("Death");
    #endregion
    #region Death Data
    [SerializeField] float _deathWaitTime = 5.0f;
    float _deathTimer = 0.0f;
    #endregion
    #region Audio Data
    [SerializeField] int _sfxToPlay = 0;
    #endregion
    public PlayerDeathState(PlayerStateMachine stateMachine) : base(stateMachine) {}
    public override void Enter() {
        _deathTimer = _deathWaitTime;
        _stateMachine.Animator.CrossFadeInFixedTime(DeathHash, CrossFadeDuration);
        AudioController.Instance.PlaySFX(_sfxToPlay);
    }
    public override void Tick(float deltaTime) {
        _deathTimer -= deltaTime;
        if (_deathTimer <= 0.0f) {
            GameController.Instance.Restart();
            _stateMachine.SwitchState(new PlayerMovementState(_stateMachine));
            return;
        }
        Move(deltaTime);
    }
    public override void Exit() {}
}