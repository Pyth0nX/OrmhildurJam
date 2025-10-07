[System.Serializable] 
public enum InteractionType { Active, Passive }

public interface IInteractable
{
    void Interact();
    InteractionType InteractionType { get; }
}