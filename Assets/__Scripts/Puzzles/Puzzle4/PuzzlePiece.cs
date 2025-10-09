using System;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour, IInteractable
{
    [SerializeField] private int puzzleIndex;
    public int PuzzleIndex => puzzleIndex;

    [SerializeField] private int currentIndex;
    public int CurrentIndex { get => currentIndex; set => currentIndex = value; }

    [SerializeField] private float speed;
    
    private Vector3 _originalPosition;
    protected ImagePuzzle OwningPuzzle;

    private bool isLocked = false;

    public void Lock()
    {
        isLocked = true;
    }
    
    private bool isDragging = false;

    private void Update()
    {
        if (!isDragging) return;
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * speed;
        Debug.Log("[PuzzlePiece] currentPos " + transform.position);
    }

    public void Interact(PlayerState interactingActor)
    {
        Debug.Log("[PuzzlePiece] Interacting " + interactingActor);
        if (isLocked) return;
        
        Debug.Log("[PuzzlePiece] is not locked");
        _originalPosition = transform.position;
        Debug.Log("[previousTransform] " + _originalPosition);
        isDragging = true;
    }

    public InteractionType InteractionType => InteractionType.Clicked;

    private void OnMouseDown()
    {
        if (InteractionType != InteractionType.Clicked) return;
        Interact(GameManager.Instance.player);
    }

    private void OnMouseUp()
    {
        isDragging = false;
        
        int hoveredIndex = OwningPuzzle.GetHoveredGridIndex();
        if (hoveredIndex == -1)
        {
            transform.position = _originalPosition;
            return;
        }
        
        PuzzlePiece otherPiece = OwningPuzzle.GetPieceAtIndex(hoveredIndex);

        if (otherPiece != null)
        {
            otherPiece.transform.position = _originalPosition;
            otherPiece.currentIndex = currentIndex;
        }
        
        transform.position = OwningPuzzle.GetGridPositionAtIndex(hoveredIndex);
        currentIndex = hoveredIndex;

        if (currentIndex == PuzzleIndex)
        {
            Lock();
        }
    }
}
