using System;
using UnityEngine;

public interface InteractAction 
{
    bool PerformAction(Interactable interactable, PlayerState interactingPlayer);
}

[Serializable]
public class PickupAction : InteractAction
{
    public bool PerformAction(Interactable interactable, PlayerState interactingPlayer)
    {
        if (interactable != null)
        {
            interactable.gameObject.SetActive(false);
            return true;
        }
        return false;
    }
}

[Serializable]
public enum IntegerPuzzleTypes { Mushroom, Slug }

[Serializable]
public class CollectionAction : InteractAction
{
    [SerializeField] private int amount;
    [SerializeField] private IntegerPuzzleTypes intType;
    
    public bool PerformAction(Interactable interactable, PlayerState interactingPlayer)
    {
        Debug.Log("Mushroom action performed");
        if (interactable != null)
        {
            interactable.gameObject.SetActive(false);
            
            if (interactingPlayer == null) return false;
            interactingPlayer.IncreaseInteger(amount, intType);
            
            return true;
        }
        else
        {
            Debug.Log("Interactable is not correct: " + (interactable) + ". interacting actor is not correct: " + (interactingPlayer));
        }
        return false;
    }
}

[Serializable]
public class CollectorAction : InteractAction
{
    [SerializeField] private int requestedAmount;
    [SerializeField] private IntegerPuzzleTypes collectType;
    
    public bool PerformAction(Interactable interactable, PlayerState interactingPlayer)
    {
        Debug.Log("Mushroom action performed");
        if (interactable != null)
        {
            interactable.gameObject.SetActive(false);
            
            if (interactingPlayer == null) return false;
            var collectedAmount = interactingPlayer.GetIntegerByType(collectType);
            if (collectedAmount > requestedAmount)
            {
                Debug.Log("You collected too much!");
            return true;
            }
            if (collectedAmount < requestedAmount)
            {
                Debug.Log("This isn't enough! Go back and collect more shroomies!");
                return true;
            }
            Debug.Log("This is enough, thank you!");
            return true;
        }
        else
        {
            Debug.Log("Interactable is not correct: " + (interactable) + ". interacting actor is not correct: " + (interactingPlayer));
        }
        return false;
    }
}