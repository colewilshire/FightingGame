using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private InputAction moveAction;
    private PlayerController playerController;
    private AnimationController animationController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        animationController = GetComponent<AnimationController>();

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
        moveAction.canceled += OnMoveEnd;

        moveAction.Enable();
    }

    private void DisableInputs()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMoveEnd;

        moveAction.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
    
        playerController.Move(direction);
        animationController.PlayAnimation(AnimationState.WalkForward);
    }

    private void OnMoveEnd(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();

        playerController.Move(direction);
        animationController.StopAnimation(AnimationState.WalkForward);
    }
}
