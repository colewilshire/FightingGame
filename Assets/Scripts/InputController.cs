using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private InputAction moveAction;

    private void Start()
    {
        EnableInputs();
    }

    private void OnDestroy()
    {
        DisableInputs();
    }

    private void EnableInputs()
    {
        playerInputActions = new PlayerInputActions();

        moveAction = playerInputActions.Movement.Move;
    
        moveAction.performed += OnMove;

        moveAction.Enable();
    }

    private void DisableInputs()
    {
        moveAction.performed -= OnMove;

        moveAction.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        AnimationController.Instance.CrossfadeAnimation(AnimationState.Walk);
    }
}
