using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    
    private CharacterController _playerController;
    private Vector2 _movementVector;
    private Vector2 _inputVector;
    
    // interacting
    private IInteractable _interactable;
    
    private void Start()
    {
        _playerController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _movementVector = _inputVector * (speed * Time.deltaTime);
        _playerController.Move(_movementVector);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var interactedObject = other.gameObject;
        if (interactedObject == null) return;
        interactedObject.TryGetComponent<IInteractable>(out _interactable);
        if (_interactable.InteractionType == InteractionType.Passive) 
        {
            _interactable.Interact();
            _interactable = null;
        }
        Debug.Log($"Found interactable: {interactedObject}");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // reset interactable
        _interactable = null;
    }

    public void Move(InputAction.CallbackContext input)
    {
        _inputVector = input.ReadValue<Vector2>();
    }

    public void Interact(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            Debug.Log($"Player Interacted with {_interactable}");
            if (_interactable == null) return;
            _interactable.Interact();
        }
    }
}
