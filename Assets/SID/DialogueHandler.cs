using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct DialogueEntry
{
    public string line;
    public string name;
    public bool isPlayer;
    public Sprite sprite;
}

public class DialogueHandler : MonoBehaviour
{
    private DialogueEntry[] dialogue;

    [SerializeField] private bool activeDialogue;

    [SerializeField] private Sprite playerSprite;
    [SerializeField] private Sprite otherSprite;

    // dialogue
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Image dialogueSprite;

    [SerializeField] private GameObject dialogueHUD;
    [SerializeField] private GameObject playerDialogue;
    [SerializeField] private GameObject otherDialogue;

    private int dialogueIndex;

    private void Start()
    {
        dialogue = new DialogueEntry[] { new DialogueEntry { name = "Ormhildur", isPlayer = true, line = "Gudur, what happened to you?!", sprite = playerSprite },
        new DialogueEntry { name = "Gudur", isPlayer = false, line = "I am Evil the spirit that controls Gudur", sprite = otherSprite },
        new DialogueEntry { name = "Ormhildur", isPlayer = true, line = "Oh no! What can I do to save you?", sprite = playerSprite },
        new DialogueEntry { name = "Gurd", isPlayer = false, line = "Only an rare artefact can cleanse me! And you will never get it!!! MUAHAHAHAHAH!", sprite = otherSprite },
        new DialogueEntry { name = "Ormhildur", isPlayer = true, line = "Don't worry, I will save you Gudur!", sprite = playerSprite }
        };
    }

    public void ActivateDialogue()
    {
        activeDialogue = !activeDialogue;
        dialogueHUD.SetActive(activeDialogue);
        NextDialogue();
    }

    private void Update()
    {
        if (!activeDialogue) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextDialogue();
        }
    }

    private void NextDialogue()
    {
        Debug.Log("NextDialogue");
        var activeDialogueEntry = dialogue[dialogueIndex];
        bool isPlayer = dialogue[dialogueIndex].isPlayer;
        playerDialogue.SetActive(isPlayer);
        otherDialogue.SetActive(!isPlayer);

        var currentDialogue = isPlayer ? playerDialogue : otherDialogue;
        nameText = currentDialogue.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        dialogueText = currentDialogue.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        //dialogueSprite = currentDialogue.transform.GetChild(2).GetComponent<Image>();

        nameText.text = activeDialogueEntry.name;
        dialogueText.text = activeDialogueEntry.line;
        //dialogueSprite.sprite = activeDialogueEntry.sprite;

        dialogueIndex++;
    }
}
