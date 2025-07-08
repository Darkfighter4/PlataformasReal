using UnityEngine;
using UnityEngine.UI;

public class PuzzlePieceUI : MonoBehaviour
{
    public PuzzlePiece pieceData; 
    public CommandManager manager;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        manager.OnPieceClicked(pieceData);
    }
}

