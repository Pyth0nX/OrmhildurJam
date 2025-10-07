using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    
    private CharacterController playerController;
    private Vector2 movementVector;
    private Vector2 inputVector;
    
    // interacting
    private IInteractable interactable;
    
    private void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        movementVector = inputVector * (speed * Time.deltaTime);
        playerController.Move(movementVector);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var interactedObject = other.gameObject;
        if (interactedObject == null) return;
        interactedObject.TryGetComponent<IInteractable>(out interactable);
        if (interactable.InteractionType == InteractionType.Passive) 
        {
            interactable.Interact();
            interactable = null;
        }
        Debug.Log($"Found interactable: {interactedObject}");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // reset interactable
        interactable = null;
    }

    public void Move(InputAction.CallbackContext input)
    {
        inputVector = input.ReadValue<Vector2>();
    }

    public void Interact(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            Debug.Log($"Player Interacted with {interactable}");
            if (interactable == null) return;
            interactable.Interact();
        }
    }
}
