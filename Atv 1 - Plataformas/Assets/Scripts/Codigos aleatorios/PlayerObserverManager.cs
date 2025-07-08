using System;
using UnityEngine;
//Youtube criado (site)
public static class PlayerObserverManager
{
    //Criar Canal
    public static event Action<int> OnMoedasChanged;
    
    //Criar o postar videos
    public static void ChangedMoedas(int moedas)
    {
        //Verifica se tem inscritos e manda a notificação
        OnMoedasChanged?.Invoke(moedas);
    }
}
