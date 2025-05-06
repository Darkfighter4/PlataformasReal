using UnityEngine;

public class MudarCena2 : MonoBehaviour
{
    private void Start()
    {
        Invoke("LoadMainMenu", 2f);
    }

    private void LoadMainMenu()
    {
       // GameManager.Instance.LoadScene("MainMenu");
    }
}

