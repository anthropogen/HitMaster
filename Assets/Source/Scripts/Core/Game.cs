using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private PressButton playButton;
    public event Action GameStarted;
    private void OnEnable()
    {
        playButton.Pressed.AddListener(StartGame);
    }

    private void OnDisable()
    {
        playButton.Pressed.RemoveAllListeners();
    }
    private void StartGame()
    {
        playButton.gameObject.SetActive(false);
        GameStarted?.Invoke();
    }
}
