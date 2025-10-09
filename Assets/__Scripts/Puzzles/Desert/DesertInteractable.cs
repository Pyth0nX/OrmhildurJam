using UnityEngine;

public class DesertInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject text;

    private SpriteRenderer sprite;

    public InteractionType InteractionType => InteractionType.Active;

    public System.Action<int, DesertInteractable> OnInteracted;

    private void Start()
    {
        text.SetActive(false);
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject + " entered trigger of " + gameObject); //check if it work
        if (other.CompareTag("Player") && sprite.enabled)
        {
            text.SetActive(true);
            //Debug.Log("Car is in the zone"); //check if it work

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (text.activeSelf)
            text.SetActive(false);
        //Debug.Log("Car is not in the zone"); //check if it work
    }

    public void Interact(PlayerState player)
    {
        if (player == null) return;

        sprite.enabled = false;
        text.SetActive(false);

        player.IncreaseInteger(1, IntegerPuzzleTypes.Desert);
        OnInteracted?.Invoke(1, this);
    }
}
