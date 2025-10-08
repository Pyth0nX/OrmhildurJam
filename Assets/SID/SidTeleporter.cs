using UnityEngine;

public class SidTeleporter : MonoBehaviour
{
    [Header("Teleport Settings")]
    public Transform teleportTarget; // Where to teleport the player
    public string targetTag = "Player"; // Optional: only teleport objects with this tag

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check tag if specified
        if (!string.IsNullOrEmpty(targetTag) && !other.CompareTag(targetTag))
            return;

        if (teleportTarget != null)
        {
            other.transform.position = teleportTarget.position;
        }
        else
        {
            Debug.LogWarning("Teleport target not assigned on " + gameObject.name);
        }
    }
}
