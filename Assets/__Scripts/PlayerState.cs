using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private Dictionary<IntegerPuzzleTypes, int> integers;
    
    public void IncreaseInteger(int incomingAmount, IntegerPuzzleTypes puzzleType)
    {
        if (!integers.ContainsKey(puzzleType))
        {
            integers.Add(puzzleType, incomingAmount);
            return;
        }
        
        integers[puzzleType] += incomingAmount;
        Debug.Log("Picked up " + incomingAmount + " mushrooms");
    }

    public int GetIntegerByType(IntegerPuzzleTypes puzzleType)
    {
        if (!integers.ContainsKey(puzzleType)) return -1;
        return integers[puzzleType];
    }
}
