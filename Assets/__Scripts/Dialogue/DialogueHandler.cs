using System;
using System.Linq;
using SerializeReferenceEditor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{
    public Action OnDialogueComplete;
    
    [Header("Dialogue")]
    [SerializeReference, SR] private IDialogueEntry sceneDialogue;

    [SerializeField] private bool activeDialogue = false;
    public bool IsDialogueActive => activeDialogue;
    [SerializeField] private bool getInvalidDialogue = false;
    [SerializeField] private string invalidDialogueLine;

    [Header("UI Elements")]
    [SerializeField] private GameObject dialogueHUD;
    [SerializeField] private GameObject playerDialogue;
    [SerializeField] private GameObject otherDialogue;
    
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI dialogueText;
    private Image dialogueSprite;
    
    private DialogueEntry[] _dialogue;
    
    private int dialogueIndex = 0;
    private bool dialogueComplete = false;

    private void Start()
    {
        _dialogue = sceneDialogue.GetDialogueEntry();
    }
    
    private void Update()
    {
        if (!activeDialogue) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextDialogue();
        }
    }

    public void AttemptEnterDialogue()
    {
        if (dialogueComplete && !getInvalidDialogue) return;
        
        ToggleDialogueHUD();
        
        if (getInvalidDialogue)
        {
            playerDialogue.SetActive(false);
            otherDialogue.SetActive(true);
            nameText = otherDialogue.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            dialogueText = otherDialogue.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

            nameText.text = _dialogue.First(de => !de.isPlayer).name;
            dialogueText.text = invalidDialogueLine;
            
            dialogueIndex = _dialogue.Length;
            return;
        }

        if (!dialogueComplete)
        {
            dialogueIndex = 0;
            NextDialogue();
        }
    }

    public void ToggleDialogueHUD()
    {
        activeDialogue = !activeDialogue;
        dialogueHUD.SetActive(activeDialogue);
    }

    private void NextDialogue()
    {
        if (dialogueComplete && !getInvalidDialogue) ToggleDialogueHUD();
        
        if (dialogueIndex >= _dialogue.Length)
        {
            OnDialogueComplete?.Invoke();
            dialogueComplete = true;
            return;
        }
        
        if (dialogueIndex >= _dialogue.Length) return;
        
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
    }
}
