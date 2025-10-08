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
public class MushroomAction : InteractAction
{
    [SerializeField] private int shroomie;
    public bool PerformAction(Interactable interactable, PlayerState interactingPlayer)
    {
        Debug.Log("Mushroom action performed");
        if (interactable != null)
        {
            interactable.gameObject.SetActive(false);
            
            if (interactingPlayer == null) return false;
            interactingPlayer.IncreaseMushroomCount(shroomie);
            
            return true;
        }
        else
        {
            Debug.Log("Interactable is not correct: " + (interactable) + ". interacting actor is not correct: " + (interactingPlayer));
        }
        return false;
    }
}