using System;
using SerializeReferenceEditor;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionType _interactionType;

    [SerializeReference, SR] private InteractAction _action;
    
    [SerializeField] private LayerMask interactionLayer;
    
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        if (gameObject.TryGetComponent(out Collider2D collider))
        {
            //collider;
        }
    }

    public void Interact(PlayerState interactingPlayer)
    {
        if ((interactionLayer.value & (1 << gameObject.layer)) == 0)
        {
            Debug.LogWarning($"[Interactable] Layer mismatch: {gameObject.name} is on layer {gameObject.layer}, not in {interactionLayer}");
            return;
        }
        
        if (interactingPlayer == null) return; 
        _action.PerformAction(this, interactingPlayer);
        if (_audioSource != null && _audioSource.clip != null) _audioSource.Play();
    }

    public InteractionType InteractionType { get => _interactionType; }

    private void OnMouseDown()
    {
        if ((interactionLayer.value & (1 << gameObject.layer)) == 0)
        {
            Debug.LogWarning($"[Interactable] Layer mismatch: {gameObject.name} is on layer {gameObject.layer}, not in {interactionLayer}");
            return;
        }
        
        if (_interactionType != InteractionType.Clicked) return;
        Interact(GameManager.Instance.player);
        Debug.Log("Clicked Interactable");
    }
}
