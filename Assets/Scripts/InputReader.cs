using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions {
    public Vector2 MovementValue { get; private set; }

    public event Action JumpEvent;

    Controls _controls;

    // Start is called before the first frame update
    void Start()
    {
        _controls = new Controls();
        _controls.Player.SetCallbacks(this);
        _controls.Player.Enable();
    }

    void OnDestroy() {
        _controls.Player.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnJump(InputAction.CallbackContext context) {
        if (context.performed) {
            JumpEvent?.Invoke();
        }
    }
    public void OnLook(InputAction.CallbackContext context) {
    }
    public void OnMove(InputAction.CallbackContext context) {
        MovementValue = context.ReadValue<Vector2>();
    }
}