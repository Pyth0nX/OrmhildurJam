using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private Dictionary<IntegerPuzzleTypes, int> integers = new();
    private Dictionary<IntegerPuzzleTypes, bool> bools = new();
    
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
    
    public void SetBool(bool incomingBool, IntegerPuzzleTypes puzzleType)
    {
        if (!bools.ContainsKey(puzzleType))
        {
            bools.Add(puzzleType, incomingBool);
            return;
        }
        
        bools[puzzleType] = incomingBool;
        Debug.Log("set " + puzzleType + " to " + incomingBool);
    }

    public bool GetBoolByType(IntegerPuzzleTypes puzzleType)
    {
        if (!bools.ContainsKey(puzzleType)) return false;
        return bools[puzzleType];
    }
}
