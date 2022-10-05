using UnityEngine;

public class ForceReceiver : MonoBehaviour {
    #region Component Data
    [SerializeField] protected CharacterController _controller;
    #endregion
    #region Gravity Data
    [SerializeField] protected float _verticalVelocity = 10.0f;
    [SerializeField] protected float _gravityModifier = 5.0f;
    #endregion
    #region Force Data
    [SerializeField] protected float _drag = 0.1f;
    protected Vector3 _impact;
    protected Vector3 _dampingVelocity;
    #endregion
    public Vector3 Movement => Vector3.up * _verticalVelocity;
    void Update() {
        if (_verticalVelocity < 0.0f && _controller.isGrounded) {
            // On ground
            // Apply small negative force to keep on ground
            _verticalVelocity = Physics.gravity.y * _gravityModifier * Time.deltaTime;
        } else {
            // Not on ground
            // Update negative force
            _verticalVelocity += Physics.gravity.y * _gravityModifier * Time.deltaTime;
        }
        _impact = Vector3.SmoothDamp(
            _impact, // Current value
            Vector3.zero, // Target value
            ref _dampingVelocity, // Current velocity
            _drag // Smooth time
        );
    }
    public virtual void AddForce(Vector3 force) {
        _impact += force;
    }
}