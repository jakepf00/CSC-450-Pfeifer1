using UnityEngine;

public class PlayerStateMachine : StateMachine {
    #region Component Data
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController CharacterController { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public PlayerForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public Targeter Targeter { get; private set; }
    [field: SerializeField] public WeaponDamage Weapon { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }
    #endregion
    #region Other Data
    [field: SerializeField] public float MovementSpeed { get; private set; } = 10.0f;
    [field: SerializeField] public float JumpForce { get; private set; } = 20.0f;
    [field: SerializeField] public Attack[] Attacks { get; private set; }
    public Transform MainCameraTransform { get; private set; }
    #endregion

    void Start() {
        MainCameraTransform = Camera.main.transform;
        SwitchState(new PlayerMovementState(this));
    }
    void OnEnable() {
        Health.DamageEvent += OnDamage;
        Health.DeathEvent += OnDeath;
    }
    void OnDisable() {
        Health.DamageEvent -= OnDamage;
        Health.DeathEvent -= OnDeath;
    }
    void OnDamage() {
        SwitchState(new PlayerImpactState(this));
    }
    void OnDeath() {
        SwitchState(new PlayerDeathState(this));
    }
}