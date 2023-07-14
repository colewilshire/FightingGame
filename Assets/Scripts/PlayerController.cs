using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float jumpHeight = 2f;
    private bool isJumping = false;
    private Rigidbody _rb;
    private Vector2 _movementInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_movementInput.x, 0, _movementInput.y) * moveSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }

    public void Move(Vector2 direction)
    {
        _movementInput = direction;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.started && !isJumping)
        {
            _rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            isJumping = true;
        }
    }
}
