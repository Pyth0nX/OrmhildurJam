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
        return false;
    }
}