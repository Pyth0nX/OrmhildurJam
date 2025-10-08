using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    
    private Rigidbody2D _rb;
    private Vector2 _movementVector;
    [SerializeField] private Vector2 _inputVector;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerState _owningPlayer;
    
    // interacting
    private IInteractable _interactable;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _owningPlayer = GetComponent<PlayerState>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //_movementVector = _inputVector * (speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _inputVector * speed;
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
        // reset interactable
        _interactable = null;
    }

    public void Move(InputAction.CallbackContext input)
    {
        _inputVector = input.ReadValue<Vector2>();
        Debug.Log($"Moving with {_inputVector}");
        _animator.SetFloat("HorizontalInput", _inputVector.x);
        _animator.SetFloat("VerticalInput", _inputVector.y);
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
}
