using System;
using UnityEngine;

public class AnimationEventReceiver : MonoBehaviour
{
    public event Action Shot;

    public void OnShot()
    {
        Shot?.Invoke();
    }
}
