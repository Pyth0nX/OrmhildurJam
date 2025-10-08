using UnityEngine;
using TMPro;

public class DesertPuzzle : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject text;

    public InteractionType InteractionType => InteractionType.Active;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject + " entered trigger of " + gameObject);
        text.GetComponent<TextMeshProUGUI>();
        if (other.CompareTag("Player"))
        {
            //text.SetActive(true);
            Debug.Log("Car is in the zone");
            
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //text.SetActive(false);
        Debug.Log("Car is not in the zone");
    }

    public void Interact(PlayerState interactingActor)
    {
        text.SetActive(false);
        Debug.Log("pressed e");
    }
}