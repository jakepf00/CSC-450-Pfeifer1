using System.Collections.Generic;
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
    [field: SerializeField] public float PlayerAttackRange { get; private set; } = 1.0f;
    [field: SerializeField] public int AttackDamage { get; private set; } = -10;
    [field: SerializeField] public float AttackKnockback { get; private set; } = 10.0f;
    public GameObject Player { get; private set; }
    #endregion
    #region Patrolling Data
    public List<Transform> Patrolpoints = new List<Transform>();
    public int CurrentPatrolpoint { get; set; } = 0;
    public float PatrolpointRange { get; private set; } = 1.0f;
    #endregion

    void Awake() {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Patrolpoint")) {
            Patrolpoints.Add(go.GetComponent<Transform>());
        }
    }
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
