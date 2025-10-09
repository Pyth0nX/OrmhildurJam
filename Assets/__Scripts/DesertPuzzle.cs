using UnityEngine;
using TMPro;

public class DesertPuzzle : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject text;
    [SerializeField] private int parts;
    [SerializeField] private GameObject plane;
    [SerializeField] private Transform planePos;

    public int partsNeeded => parts;

    public InteractionType InteractionType => InteractionType.Active;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject + " entered trigger of " + gameObject); //check if it work
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
            //Debug.Log("Car is in the zone"); //check if it work

        }
    }

    private void Start()
    {
        text.SetActive(false);
    }

    private void Update()
    {
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        text.SetActive(false);
        //Debug.Log("Car is not in the zone"); //check if it work

        if (partsNeeded == 5)
        {
            plane.transform.position = planePos.position;
        }
    }

    public void Interact(PlayerState player)
    {
        if (player == null) return;
        
        var sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        text.SetActive(false);

        player.IncreaseInteger(1, IntegerPuzzleTypes.Desert);
        var currentShrooms = player.GetIntegerByType(IntegerPuzzleTypes.Desert);
        Debug.Log("parts: " + currentShrooms);
    }
}
