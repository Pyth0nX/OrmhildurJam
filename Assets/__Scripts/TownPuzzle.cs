using UnityEngine;
using TMPro;

public class TownSeagull : MonoBehaviour
{
    [SerializeField]
    private string tagToDisappear = "Seagull";
    public int SeagullCount = 6;
    public int disappearCount = 0;
    public TextMeshProUGUI countText; // Reference to the Text component

    void OnMouseDown()
    {
        if (gameObject.CompareTag(tagToDisappear))
        {
            disappearCount++;
            UpdateCountText();
            Destroy(gameObject);
        }
    }

    void UpdateCountText()
    {
        if (countText != null)
        {
            countText.text = $"Seagulls left: {SeagullCount - disappearCount}";
        }
    }

    void Start()
    {
        UpdateCountText();
    }

    void Update()
    {

    }
}