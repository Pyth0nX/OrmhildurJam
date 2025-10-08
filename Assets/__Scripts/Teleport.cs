using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject teleportTo;
    [SerializeField] private int room;
    [SerializeField] private int prevRoom = -1;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TogglePlayerCollision(other.gameObject));
            other.transform.position = teleportTo.transform.position;
        }
    }

    private IEnumerator TogglePlayerCollision(GameObject player)
    {
        var playerCollider = player.GetComponent<CapsuleCollider2D>();
        playerCollider.enabled = false;
        GameManager.Instance.SwapCamera(room, prevRoom);
        yield return new WaitForSeconds(3f);
        playerCollider.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) return;
    }
}
