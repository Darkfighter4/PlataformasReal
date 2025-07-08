using System;
using UnityEngine;

public static class DoorController
{
    public static Action<string> OnButtonPressed;

    public static void ButtonPressed(string doorID)
    {
        OnButtonPressed?.Invoke(doorID);
    }
}

