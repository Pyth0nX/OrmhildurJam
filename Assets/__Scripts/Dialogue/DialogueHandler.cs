using System;
using SerializeReferenceEditor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{
    public Action OnDialogueComplete;
    
    [Header("Dialogue")]
    [SerializeReference, SR] private IDialogueEntry sceneDialogue;

    [SerializeField] private bool activeDialogue;

    [Header("UI Elements")]
    [SerializeField] private GameObject dialogueHUD;
    [SerializeField] private GameObject playerDialogue;
    [SerializeField] private GameObject otherDialogue;
    
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI dialogueText;
    private Image dialogueSprite;
    
    private DialogueEntry[] _dialogue;
    
    private int dialogueIndex;
    private bool dialogueComplete;

    private void Start()
    {
        _dialogue = sceneDialogue.GetDialogueEntry();
    }

    public void ActivateDialogue()
    {
        activeDialogue = !activeDialogue;
        dialogueHUD.SetActive(activeDialogue);
        if (!dialogueComplete) NextDialogue();
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
        if (dialogueComplete) ActivateDialogue();
        
        Debug.Log("NextDialogue");
        var activeDialogueEntry = _dialogue[dialogueIndex];
        bool isPlayer = _dialogue[dialogueIndex].isPlayer;
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

        if (dialogueIndex >= _dialogue.Length)
        {
            OnDialogueComplete?.Invoke();
            dialogueComplete = true;
        }
    }
}
