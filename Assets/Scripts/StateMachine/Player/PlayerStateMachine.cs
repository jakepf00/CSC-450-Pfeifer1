using UnityEngine;

public class PlayerStateMachine : StateMachine {
    #region Component Data
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController CharacterController { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    #endregion
    #region Other Data
    [field: SerializeField] public float MovementSpeed { get; private set; } = 10.0f;
    public Transform MainCameraTransform { get; private set; }
    #endregion

    void Start() {
        MainCameraTransform = Camera.main.transform;
        SwitchState(new PlayerMovementState(this));
    }
}