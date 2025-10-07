using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{

    [SerializeField] private InteractionType interactionType;

    private InteractAction action;
    
    public void Interact()
    {
        action.PerformAction(this);
    }

    public InteractionType InteractionType { get => interactionType; }
}
