[System.Serializable] 
public enum InteractionType { Active, Passive, Clicked }

public interface IInteractable
{
    void Interact(object interactingActor);
    InteractionType InteractionType { get; }
}