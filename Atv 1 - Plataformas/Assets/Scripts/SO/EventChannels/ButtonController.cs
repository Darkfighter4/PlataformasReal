using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [Header("Enviando...")]
    public VoidEventChannel circleColorEvent;

    public void MudaCor()
    {
        circleColorEvent.RaiseEvent();
    }
}
