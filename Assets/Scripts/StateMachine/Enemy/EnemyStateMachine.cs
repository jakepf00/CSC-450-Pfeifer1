using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine {
    #region Component Data
    [field: SerializeField] public CharacterController CharacterController { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public EnemyForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public WeaponDamage Weapon { get; private set; }
    [field: SerializeField] public NavMeshAgent NavMeshAgent { get; private set; }
    #endregion
    #region Other Data
    [field: SerializeField] public float MovementSpeed { get; private set; } = 5.0f;
    [field: SerializeField] public float PlayerChaseRange { get; private set; } = 7.0f;
    [field: SerializeField] public float PlayerAttackRange { get; private set; } = 1.5f;
    [field: SerializeField] public int AttackDamage { get; private set; } = -10;
    public GameObject Player { get; private set; }
    #endregion
    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
        NavMeshAgent.updatePosition = false;
        NavMeshAgent.updateRotation = false;
        SwitchState(new EnemyIdleState(this));
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PlayerChaseRange);
    }
}
