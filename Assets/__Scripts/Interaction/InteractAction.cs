using System;

public interface InteractAction
{
    bool PerformAction(object obj);
}

[Serializable]
public class PickupAction : InteractAction
{
    public bool PerformAction(object obj)
    {
        if (obj is Interactable interactableObj)
        {
            interactableObj.gameObject.SetActive(false);
            return true;
        }
        return false;
    }
}