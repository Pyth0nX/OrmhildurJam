using UnityEngine;
using TMPro;

public class TownSeagull : MonoBehaviour
{
    public string tagToDisappear = "Seagull";

    public static int SeagullCount = 6;
    public static int disappearCount = 0;
    public static TextMeshProUGUI countText;

    // Assign this in the Inspector only once (e.g., on the first seagull)
    public TextMeshProUGUI referenceText;

    void Start()
    {
        // Only assign countText once
        if (countText == null && referenceText != null)
        {
            countText = referenceText;
            UpdateCountText();
        }
    }

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
}