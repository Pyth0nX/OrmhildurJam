using System;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private int mushrooms;
    InteractionType _interactionType;
    public int MushroomCount => mushrooms;
    public void IncreaseMushroomCount(int incomingAmount)
    {
        mushrooms += incomingAmount;
        Debug.Log("Picked up " + incomingAmount + " mushrooms");
    }
}
