using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{

    [SerializeField] private InteractionType interactionType;

    private InteractAction action = new PickupAction();
    
    public void Interact()
    {
        action.PerformAction(this);
    }

    public InteractionType InteractionType { get => interactionType; }

    private void OnMouseDown()
    {
        if (interactionType != InteractionType.Clicked) return;
        Interact();
        Debug.Log("Clicked Interactable");
    }
}
