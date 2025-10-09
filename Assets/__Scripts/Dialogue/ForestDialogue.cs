using UnityEngine;

public struct ForestDialogue : IDialogueEntry
{
    [SerializeField] private Sprite playerSprite;
    [SerializeField] private Sprite otherSprite;
    
    public DialogueEntry[] GetDialogueEntry() => new DialogueEntry[]
    {
        new DialogueEntry
        {
            name = "Ormhildur",
            line = "Gudur, what happened to you?!",
            isPlayer = true,
        },
        new DialogueEntry
        {
            name = "Gudur", 
            line = "I am Evil the spirit that controls Gudur",
            isPlayer = false, 
            sprite = otherSprite
        },
        new DialogueEntry
        {
            name = "Ormhildur", 
            line = "Oh no! What can I do to save you?", 
            isPlayer = true, 
            sprite = playerSprite
            
        },
        new DialogueEntry
        {
            name = "Gurd", 
            line = "Only an rare artefact can cleanse me! And you will never get it!!! MUAHAHAHAHAH!",
            isPlayer = false,
            sprite = otherSprite
        },
        new DialogueEntry
        {
            name = "Ormhildur", 
            line = "Don't worry, I will save you Gudur!", 
            isPlayer = true, 
            sprite = playerSprite
        }
    };
}