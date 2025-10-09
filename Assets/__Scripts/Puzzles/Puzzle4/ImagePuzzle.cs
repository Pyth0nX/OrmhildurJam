using System.Linq;
using UnityEngine;

public class ImagePuzzle : MonoBehaviour
{
    [SerializeField] private PuzzlePiece[] puzzlePieces;
    
    [SerializeField] private Transform[] gridSlots;
    
    private void Start()
    {
        StartPuzzle();
    }

    public void StartPuzzle()
    {
        ShufflePieces();
    }

    private void ShufflePieces()
    {
        Debug.Log("gridslots: " + gridSlots.Length + " - PuzzlePieces: " + puzzlePieces.Length);
        
        int[] availableIndices = new int[gridSlots.Length];
        for (int i = 0; i < availableIndices.Length; i++)
            availableIndices[i] = i;

        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            PuzzlePiece piece = puzzlePieces[i];

            int randomIndex;
            do
            {
                randomIndex = availableIndices[Random.Range(0, availableIndices.Length)];
            } while (randomIndex == piece.CurrentIndex || randomIndex == -1);

            piece.transform.position = gridSlots[randomIndex].position;
            piece.CurrentIndex = randomIndex;

            availableIndices[randomIndex] = -1; // Mark as used
        }
    }

    public int GetHoveredGridIndex()
    {
        return 0;
    }

    public Vector3 GetGridPositionAtIndex(int index)
    {
        return gridSlots[index].position;
    }

    public PuzzlePiece GetPieceAtIndex(int index)
    {
        return puzzlePieces.FirstOrDefault(piece => piece.GetComponent<PuzzlePiece>().CurrentIndex == index).GetComponent<PuzzlePiece>();
    }
}
