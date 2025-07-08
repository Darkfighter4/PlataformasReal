using System;
using TMPro;
using UnityEngine;

public class MoedasTextController : MonoBehaviour
{
    public TMP_Text moedasText;

    private void OnValidate()
    {
        moedasText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        //se inscreve no canal de moedas
        PlayerObserverManager.OnMoedasChanged += AtualizarMoedas;
    }

    private void OnDisable()
    {
        //se desinscreve no canal de moedas
        PlayerObserverManager.OnMoedasChanged -= AtualizarMoedas;
    }

    private void AtualizarMoedas(int valor)
    {
        moedasText.text = "Moedas: " + valor.ToString();
    }
}
