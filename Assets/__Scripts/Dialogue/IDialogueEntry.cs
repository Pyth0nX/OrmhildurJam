using UnityEngine;

public interface IDialogueEntry
{
    public DialogueEntry[] GetDialogueEntry();
}

[System.Serializable]
public struct DialogueEntry
{
    public string line;
    public string name;
    public bool isPlayer;
    public Sprite sprite;
}

public struct ExampleDialogue : IDialogueEntry
{
    public DialogueEntry[] GetDialogueEntry() => new DialogueEntry[]
    {
        new DialogueEntry
        {
            name = "name",
            line = "dialogue",
            isPlayer = false,
        },
    };
}