using SerializeReferenceEditor;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionType _interactionType;

    [SerializeReference, SR] private InteractAction _action;
    
    public void Interact(PlayerState interactingPlayer)
    {
        if (interactingPlayer == null) return; 
        _action.PerformAction(this, interactingPlayer);
    }

    public InteractionType InteractionType { get => _interactionType; }

    private void OnMouseDown()
    {
        if (_interactionType != InteractionType.Clicked) return;
        Interact(GameManager.Instance.player);
        Debug.Log("Clicked Interactable");
    }
}
