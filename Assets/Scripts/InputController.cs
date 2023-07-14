using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private InputAction moveAction;
    private AnimationController animationController;
    private PlayerController playerController;

    private void Start()
    {
        //animationController = GetComponent<AnimationController>();
        playerController = GetComponent<PlayerController>();

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
        moveAction.canceled += OnMove;

        moveAction.Enable();
    }

    private void DisableInputs()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;

        moveAction.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        //animationController.CrossfadeAnimation(AnimationState.AxeKick);
        playerController.Move(context.ReadValue<Vector2>());
    }
}
