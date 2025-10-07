[System.Serializable] 
public enum InteractionType { Active, Passive, Clicked }

public interface IInteractable
{
    void Interact();
    InteractionType InteractionType { get; }
}