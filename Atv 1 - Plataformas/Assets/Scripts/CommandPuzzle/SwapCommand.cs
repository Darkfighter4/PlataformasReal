using UnityEngine;

public class SwapCommand : ICommand
{
    private PuzzlePiece pieceA, pieceB;

    public SwapCommand(PuzzlePiece a, PuzzlePiece b)
    {
        pieceA = a;
        pieceB = b;
    }

    public void Do()
    {
        SwapPositions();
    }

    public void Undo()
    {
        SwapPositions(); 
    }

    private void SwapPositions()
    {
        RectTransform rtA = pieceA.GetComponent<RectTransform>();
        RectTransform rtB = pieceB.GetComponent<RectTransform>();

        Vector2 tempPos = rtA.anchoredPosition;
        rtA.anchoredPosition = rtB.anchoredPosition;
        rtB.anchoredPosition = tempPos;

        var temp = pieceA.currentPosition;
        pieceA.currentPosition = pieceB.currentPosition;
        pieceB.currentPosition = temp;
    }

}


