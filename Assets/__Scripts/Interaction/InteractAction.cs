using System;
using UnityEngine;

public interface InteractAction 
{
    bool PerformAction(object obj, object interactingActor);
}

[Serializable]
public class PickupAction : InteractAction
{
    public bool PerformAction(object obj, object interacter)
    {
        if (obj is Interactable interactableObj && interacter is PlayerController interactorPlayer)
        {
            interactableObj.gameObject.SetActive(false);
            // interact with player here
            //var playerState = interactorPlayer.GetComponent<PlayerState>();
            //playerState
            return true;
        }
        return false;
    }
}

[Serializable]
public class MushroomAction : InteractAction
{
    [SerializeField] private int shroomie;
    public bool PerformAction(object obj, object interacter)
    {
        if (obj is Interactable interactableObj && interacter is PlayerController interactorPlayer)
        {
            interactableObj.gameObject.SetActive(false);
            // interact with player here
            var playerState = interactorPlayer.GetComponent<PlayerState>();
            playerState.IncreaseMushroomCount(shroomie);
            return true;
        }
        return false;
    }
}