using UnityEngine;

public class DesertPlane : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject text;
    [SerializeField] private Transform targetPos;
    [SerializeField] private float planeSpeed; 
    [SerializeField] private DesertPuzzle desertManager;
    [SerializeField] private LoadScene scene;

    private SpriteRenderer sprite;
    private bool fly = false;

    public InteractionType InteractionType => InteractionType.Active;

    private void Start()
    {
        text.SetActive(false);
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!fly) return;

        transform.position = Vector3.MoveTowards(transform.position, targetPos.position, Time.deltaTime * planeSpeed);

        GameManager.Instance.CompleteLevel(scene.LevelName);
        if (Vector3.Distance(transform.position, targetPos.position) < 0.1f)
        {
            scene.GetComponent<LoadScene>().CompleteScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && sprite.enabled)
        {
            text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (text.activeSelf)
            text.SetActive(false);
    }

    public void Interact(PlayerState player)
    {
        if (player == null) return;

        TakeOff();
    }

    private void TakeOff()
    {
        if (!desertManager.HasCompletedObjective())
        {
            Debug.Log("You haven't collected all the parts yet!");
            return;
        }

        Debug.Log("You have collected all the parts! You win!");
        fly = true;
    }
}
