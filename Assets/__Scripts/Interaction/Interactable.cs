using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{

    [SerializeField] private InteractionType _interactionType;

    private InteractAction _action = new PickupAction();
    
    public void Interact()
    {
        _action.PerformAction(this);
    }

    public InteractionType InteractionType { get => _interactionType; }

    private void OnMouseDown()
    {
        if (_interactionType != InteractionType.Clicked) return;
        Interact();
        Debug.Log("Clicked Interactable");
    }
}
