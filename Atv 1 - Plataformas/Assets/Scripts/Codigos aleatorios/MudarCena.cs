using UnityEngine;

public class MudarCena : MonoBehaviour
{
    private void Start()
    {
        Invoke("LoadSplash", 1f);
    }

    private void LoadSplash()
    {
       // GameManager.Instance.LoadScene("Splash");
    }
}

