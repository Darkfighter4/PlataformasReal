using UnityEngine;

public class Door : MonoBehaviour
{
    public string doorID;

    private void OnEnable()
    {
        DoorController.OnButtonPressed += OnButtonPressed;
    }

    private void OnDisable()
    {
        DoorController.OnButtonPressed -= OnButtonPressed;
    }

    private void OnButtonPressed(string triggeredID)
    {
        if (triggeredID == doorID)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}

