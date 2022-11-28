using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions {
    #region Event Data
    public bool IsAttacking { get; private set; } = false;
    public Vector2 MovementValue { get; private set; }
    public event Action JumpEvent;
    public event Action PauseEvent;
    Controls _controls;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _controls = new Controls();
        _controls.Player.SetCallbacks(this);
        _controls.Player.Enable();
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
    public void OnAttack(InputAction.CallbackContext context) {
        if (context.performed) {
            IsAttacking = true;
        }
        else if (context.canceled) {
            IsAttacking = false;
        }
    }
    public void OnPause(InputAction.CallbackContext context) {
        if (context.performed) {
            PauseEvent?.Invoke();
        }
    }
}