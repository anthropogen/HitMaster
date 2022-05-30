using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private PressButton playButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Player player;
    [SerializeField] private PlatformMover platformMover;
    public event Action GameStarted;
    private void OnEnable()
    {
        platformMover.PlayerReachedFinish += OnPlayerReachedFinish;
        playButton.Pressed.AddListener(StartGame);
        restartButton.onClick.AddListener(RestartGame);
    }


    private void OnDisable()
    {
        platformMover.PlayerReachedFinish -= OnPlayerReachedFinish;
        playButton.Pressed.RemoveAllListeners();
        restartButton.onClick.RemoveAllListeners();
    }
    private void StartGame()
    {
        playButton.gameObject.SetActive(false);
        player.Gunner.enabled = true;
        GameStarted?.Invoke();
    }
    private void OnPlayerReachedFinish()
    {
        player.Gunner.enabled = false;
        restartButton.gameObject.SetActive(true);
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
