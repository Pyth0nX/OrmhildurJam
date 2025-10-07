using UnityEngine;
using TMPro;

public class TownSeagull : MonoBehaviour
{
    public string tagToDisappear = "Seagull"; 
    public int SeagullCount = 6;
    public int disappearCount = 0;
    public TextMeshProUGUI countText;

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
}