using System;
using UnityEngine;

public class NPCComponent : MonoBehaviour
{
    [SerializeField] private DialogueHandler dialogueHandler;

    private void OnEnable()
    {
        dialogueHandler.OnDialogueComplete += Implemented_OnDialogueComplete;
    }

    private void OnDisable()
    {
        dialogueHandler.OnDialogueComplete -= Implemented_OnDialogueComplete;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject + " Entered Collision with: " + gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject + " is player");
            dialogueHandler.AttemptEnterDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (dialogueHandler.IsDialogueActive) dialogueHandler.AttemptEnterDialogue();
        }
    }

    private void Implemented_OnDialogueComplete()
    {
        GameManager.Instance.CompleteLevel();
    }
}
