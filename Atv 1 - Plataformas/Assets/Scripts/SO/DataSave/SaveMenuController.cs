using UnityEngine;

public class SaveMenuController : MonoBehaviour
{
    public CircleController playerCircle;
    
    public void SaveSO()
    {
        SaveManager.Instance.saveData.SaveCircleColor(playerCircle._spriteRenderer.color);
    }

    public void LoadSO()
    {
        playerCircle._spriteRenderer.color = SaveManager.Instance.saveData.CircleColor;
    }

    public void SaveFile()
    {
        SaveManager.Instance.WriteSaveToFile();
    }

    public void LoadFile()
    {
        SaveManager.Instance.LoadSaveFromFile();
        LoadSO();
    }
}
