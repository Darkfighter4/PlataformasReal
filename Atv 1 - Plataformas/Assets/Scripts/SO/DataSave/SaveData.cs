using UnityEngine;

public class SaveData : MonoBehaviour
{
    public SaveDataSO saveDataSo;
    
    public Color CircleColor=>saveDataSo.circleColor;

    public void SaveCircleColor(Color color)
    {
        saveDataSo.circleColor = color;
    }
}
