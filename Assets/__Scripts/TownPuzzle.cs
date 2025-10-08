using UnityEngine;
using TMPro;

public class TownSeagull : MonoBehaviour
{
    public string chaseAway = "Seagull";
    public string blockedKitten = "tagToDisappear";

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
        if (gameObject.CompareTag(chaseAway))
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
    // if touched all seagulls, remove kitten with tag "tagToDisappear"
    void Update()
    {
        if (disappearCount >= SeagullCount)
        {
            GameObject kitten = GameObject.FindGameObjectWithTag(blockedKitten);
            if (kitten != null)
            {
                Destroy(kitten);
            }
        }
    }
}