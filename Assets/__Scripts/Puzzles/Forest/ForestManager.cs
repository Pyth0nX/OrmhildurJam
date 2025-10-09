using System;
using UnityEngine;

public class ForestManager : MonoBehaviour
{
    [SerializeField] private DialogueHandler dialogueHandler;
    [SerializeField] private GameObject gameManager;

    [SerializeField] private int puzzlesToComplete;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        dialogueHandler.OnDialogueComplete += Implemented_OnDialogueComplete;
    }

    private void OnDisable()
    {
        dialogueHandler.OnDialogueComplete -= Implemented_OnDialogueComplete;
    }

    private void Implemented_OnDialogueComplete()
    {
        
    }
}
