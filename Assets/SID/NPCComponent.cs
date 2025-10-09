using UnityEngine;

public class NPCComponent : MonoBehaviour
{
    [SerializeField] private DialogueHandler dialogueHandler;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject + " Entered Collision with: " + gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision.gameObject + " is player");
            dialogueHandler.ActivateDialogue();
        }
    }
}
