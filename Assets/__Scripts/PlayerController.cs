using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    
    private CharacterController playerController;
    private PlayerInput playerInput;
    private Vector2 movementVector;
    private Vector2 inputVector;
    
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        movementVector = inputVector * (speed * Time.deltaTime);
        playerController.Move(movementVector);
    }
    
    public void Move(InputAction.CallbackContext input)
    {
        inputVector = input.ReadValue<Vector2>();
    }
}
