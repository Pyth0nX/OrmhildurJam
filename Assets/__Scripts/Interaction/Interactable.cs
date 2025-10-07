using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionType _interactionType;

    private InteractAction _action = new PickupAction();
    
    private object _interactingActor;
    
    public void Interact(object interactingActor)
    {
        _interactingActor = interactingActor;
        _action.PerformAction(this, _interactingActor);
    }

    public InteractionType InteractionType { get => _interactionType; }

    private void OnMouseDown()
    {
        if (_interactionType != InteractionType.Clicked) return;
        Interact(_interactingActor);
        Debug.Log("Clicked Interactable");
    }
}
