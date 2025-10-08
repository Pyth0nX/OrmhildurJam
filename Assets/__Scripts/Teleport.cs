using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject teleportTo;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TogglePlayerCollision(other.gameObject));
            other.gameObject.SetActive(false);
            other.transform.position = teleportTo.transform.position;
            other.gameObject.SetActive(true);

        }
    }

    private IEnumerator TogglePlayerCollision(GameObject player)
    {
        var playerCollider = player.GetComponent<CapsuleCollider2D>();
        playerCollider.enabled = false;
        yield return new WaitForSeconds(3f);
        playerCollider.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) return;
    }
}
