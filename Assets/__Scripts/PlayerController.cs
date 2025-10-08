using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    
    [SerializeField] private PlayerState _owningPlayer;
    
    private AnimationController _animController;
    private Rigidbody2D _rb;
    private Vector2 _movementVector;
    private Vector2 _inputVector;
    private float _sprintBonus;
    
    // interacting
    private IInteractable _interactable;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _owningPlayer = GetComponent<PlayerState>();
        _animController = GetComponent<AnimationController>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _movementVector * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var interactedObject = other.gameObject;
        if (interactedObject == null) return;
        
        interactedObject.TryGetComponent<IInteractable>(out _interactable);
        
        if (_interactable.InteractionType == InteractionType.Passive)
        {
            _interactable.Interact(_owningPlayer);
            _interactable = null;
        }
        Debug.Log($"Found interactable: {interactedObject}");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _interactable = null;
    }

    public void Move(InputAction.CallbackContext input)
    {
        _inputVector = input.ReadValue<Vector2>();
        UpdateMovementVector();
    }
    
    public void Run(InputAction.CallbackContext input)
    {
        if (input.started) _sprintBonus = 2f;
        else if (input.canceled) _sprintBonus = 1f;
        UpdateMovementVector();
    }

    public void Interact(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            Debug.Log($"Player Interacted with {_interactable}");
            if (_interactable == null) return;
            _interactable.Interact(_owningPlayer);
        }
    }
    
    public void Jump(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            Debug.Log($"Player Jumped");
        }
    }

    private void UpdateMovementVector()
    {
        _movementVector = _inputVector * _sprintBonus;
        _animController.Input(_movementVector);
    }
}
