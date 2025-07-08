using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Button botaoStart;
    public Button botaoQuit;

    private void Start()
    {
        botaoStart.onClick.AddListener(StartGame);
        botaoQuit.onClick.AddListener(QuitGame);
    }

    private void StartGame()
    {
        //GameManager.Instance.LoadScene("Game");
        //GameManager.Instance.LoadSceneAndGUI();
    }

    private void QuitGame()
    {
        Application.Quit();
    }
    
}

