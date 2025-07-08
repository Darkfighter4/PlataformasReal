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

    public void MudaCorVermelho()
    {
        MudaCorEspecifica(Color.red);
    }
    
    public void MudaCorPreto()
    {
        MudaCorEspecifica(Color.black);
    }
    
    public void MudaCorVerde()
    {
        MudaCorEspecifica(Color.green);
    }

    public void MudaCorEspecifica(Color corEspecifica)
    {
        circleSpecificColorEvent.RaiseEvent(corEspecifica);
    }
    
    
}
