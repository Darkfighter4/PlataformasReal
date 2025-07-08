using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [Header("Enviando...")]
    public VoidEventChannel circleColorEvent;
    public ColorEventChannel circleSpecificColorEvent;
    
    public void MudaCor()
    {
        circleColorEvent.RaiseEvent();
    }

    public void MudaCorEspecifica(Color corEspecifica)
    {
        circleSpecificColorEvent.RaiseEvent(corEspecifica);
    }
    
    
}
