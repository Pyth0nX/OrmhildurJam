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
            name = "Ormhildur",
            line = "Yeah, what do you need?",
            isPlayer = true,
        },
        
        new DialogueEntry
        {
            name = "Slug",
            line = "I am in need of some mushrooms, and despite my size, I cannot collect them myself as the exit's blocked.",
            isPlayer = false,
        },
        
        new DialogueEntry
        {
            name = "Slug",
            line = "So could you collect some for me?",
            isPlayer = false,
        },
        
        new DialogueEntry
        {
            name = "Ormhildur",
            line = "Aww, I'm so sorry, of course I'll help you!",
            isPlayer = true,
        },
        
        new DialogueEntry
        {
            name = "Slug",
            line = "Wonderful, I will need no more than 37 mushrooms.",
            isPlayer = false,
        },
        
        new DialogueEntry
        {
            name = "Ormhildur",
            line = "I'm on it!",
            isPlayer = true,
        },
        
        new DialogueEntry()
    };
}
public struct CaveFinishedDialogue : IDialogueEntry
{
    public DialogueEntry[] GetDialogueEntry() => new DialogueEntry[]
    {
        new DialogueEntry
        {
            name = "Slug",
            line = "Hello human, could you do me a favour?",
            isPlayer = false,
        },

    };
}