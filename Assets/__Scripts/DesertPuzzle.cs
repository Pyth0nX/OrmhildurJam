using UnityEngine;
using TMPro;

public class DesertPuzzle : MonoBehaviour
{
    [SerializeField] private int parts;
    [SerializeField] private GameObject plane;
    [SerializeField] private Transform planePos;
    [SerializeField] private Transform collectables;

    private DesertInteractable[] interactables;

    public int partsNeeded = 1;

    private void Awake()
    {
        partsNeeded = collectables.childCount;
        interactables = new DesertInteractable[partsNeeded];

        for (int i = 0; i < collectables.childCount; i++)
        {
            var interactable = collectables.GetChild(i).GetComponent<DesertInteractable>();
            interactables[i] = interactable;
        }
    }

    private void OnEnable()
    {
        if (interactables == null) return;

        foreach (var interactable in interactables)
        {
            if (interactable != null)
            {
                interactable.OnInteracted += Desert_OnInteractable;
            }
        }
    }

    private void OnDisable()
    {
        foreach (var interactable in interactables)
        {
            if (interactable != null)
            {
                interactable.OnInteracted -= Desert_OnInteractable;
            }
        }
    }

    private void Update()
    {/*
        if (partsNeeded == parts)
        {
            plane.transform.position = planePos.position;
        }*/
    }

    public bool HasCompletedObjective()
    {
        return partsNeeded == parts;
    }

    private void Desert_OnInteractable(int value, DesertInteractable interactedObj)
    {
        parts += value;
        interactedObj.OnInteracted -= Desert_OnInteractable;
    }
}
