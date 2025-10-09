using UnityEngine;

public class HealGudur : MonoBehaviour
{
    [Header("Interaction Settings")]
    public string artefactTag = "Artefact";       // Tag for artefacts
    public string targetTag = "TargetObject";     // Tag for objects you can delete
    public KeyCode interactKey = KeyCode.F;       // Interaction key

    private bool hasArtefact = false;
    private GameObject currentTarget = null;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Collect artefact
        if (other.CompareTag(artefactTag))
        {
            hasArtefact = true;
            Destroy(other.gameObject); // Remove artefact from scene
            Debug.Log("Artefact collected!");
        }

        // Enter target area
        if (other.CompareTag(targetTag))
        {
            currentTarget = other.gameObject;
            Debug.Log("You can interact with the target now (press F).");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Leaving target area
        if (other.CompareTag(targetTag) && currentTarget == other.gameObject)
        {
            currentTarget = null;
        }
    }

    void Update()
    {
        // Check if player can press F
        if (hasArtefact && currentTarget != null && Input.GetKeyDown(interactKey))
        {
            Destroy(currentTarget);
            hasArtefact = false; // consume the artefact
            Debug.Log("Target destroyed!");
        }
    }
}
