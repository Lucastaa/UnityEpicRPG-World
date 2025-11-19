using System;
using UnityEngine;


public class InputEvents
{
    public event Action onSubmitPressed;

    public void SubmitPressed()
    {
        onSubmitPressed?.Invoke();
    }
}
