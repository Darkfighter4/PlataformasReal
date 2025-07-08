using UnityEngine;

public class ClickablePiece : MonoBehaviour
{
    public CommandManager manager;

    private void OnMouseDown()
    {
        Debug.Log("Cliquei em: " + gameObject.name); 
        manager.OnPieceClicked(GetComponent<PuzzlePiece>());
    }
    
    
}

