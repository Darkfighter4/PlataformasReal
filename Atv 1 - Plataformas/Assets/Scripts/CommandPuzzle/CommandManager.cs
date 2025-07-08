using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CommandManager : MonoBehaviour
{
    private float pieceSizeX;
    private float pieceSizeY;

    private Stack<ICommand> history = new Stack<ICommand>();
    private List<ICommand> replayList = new List<ICommand>();

    public List<PuzzlePiece> allPieces;

    private PuzzlePiece selectedPiece = null;

    public void ExecuteCommand(ICommand command)
    {
        command.Do();
        history.Push(command);
        replayList.Add(command);
        CheckWin();
    }

    public void UndoLastCommand()
    {
        if (history.Count > 0)
        {
            ICommand cmd = history.Pop();
            cmd.Undo();
        }
    }

    public void ReplayAllCommands(Action onComplete)
    {
        StartCoroutine(ReplayCoroutine(onComplete));
    }

    private IEnumerator ReplayCoroutine(Action onComplete)
    {
        foreach (var cmd in replayList)
        {
            cmd.Do();
            yield return new WaitForSeconds(1f);
        }
        onComplete?.Invoke();
    }

    public void SkipReplay(Action onComplete)
    {
        foreach (var cmd in replayList)
        {
            cmd.Do();
        }
        onComplete?.Invoke();
    }

    public void OnPieceClicked(PuzzlePiece clickedPiece)
    {
        if (selectedPiece == null)
        {
            selectedPiece = clickedPiece;
        }
        else
        {
            if (clickedPiece != selectedPiece)
            {
                ExecuteCommand(new SwapCommand(selectedPiece, clickedPiece));
            }
            selectedPiece = null;
        }
    }

    private void CheckWin()
    {
        foreach (var piece in allPieces)
        {
            if (piece.currentPosition != piece.correctPosition)
                return;
        }

        Debug.Log("Vitória!");
    }
    

    
    void Start()
    {
        if (allPieces == null || allPieces.Count == 0)
        {
            allPieces = new List<PuzzlePiece>(GetComponentsInChildren<PuzzlePiece>());
        }

        RectTransform rt = allPieces[0].GetComponent<RectTransform>();
        pieceSizeX = rt.rect.width;
        pieceSizeY = rt.rect.height;

        DetectCorrectPositions();
        ShufflePieces();
    }

    
    private void DetectCorrectPositions()
    {
        
        int gridSize = 4; 

        for (int i = 0; i < allPieces.Count; i++)
        {
            int x = i % gridSize;      
            int y = i / gridSize;      

            allPieces[i].correctPosition = new Vector2Int(x, y);

            RectTransform rt = allPieces[i].GetComponent<RectTransform>();

            
            rt.anchoredPosition = new Vector2(x * pieceSizeX, -y * pieceSizeY); 

            allPieces[i].currentPosition = allPieces[i].correctPosition;
        }
    }


    
    void ShufflePieces()
    {
        System.Random rng = new System.Random();

        for (int i = 0; i < allPieces.Count; i++)
        {
            int j = rng.Next(i, allPieces.Count);

            RectTransform rtA = allPieces[i].GetComponent<RectTransform>();
            RectTransform rtB = allPieces[j].GetComponent<RectTransform>();

            Vector2 tempPos = rtA.anchoredPosition;
            rtA.anchoredPosition = rtB.anchoredPosition;
            rtB.anchoredPosition = tempPos;

            var tempGrid = allPieces[i].currentPosition;
            allPieces[i].currentPosition = allPieces[j].currentPosition;
            allPieces[j].currentPosition = tempGrid;
        }
    }


}



