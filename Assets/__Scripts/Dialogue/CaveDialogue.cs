using UnityEngine;

public struct CaveDialogue : IDialogueEntry
{
    public DialogueEntry[] GetDialogueEntry() => new DialogueEntry[]
    {
        new DialogueEntry
        {
            name = "Slug",
            line = "Hello human, could you do me a favour?",
            isPlayer = false,
        },
        
        new DialogueEntry
        {
            name = "name",
            line = "dialogue",
            isPlayer = false,
        },
    };
}
