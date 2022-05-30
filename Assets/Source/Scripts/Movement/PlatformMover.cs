using System;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private LevelConfig levelConfig;
    [SerializeField] private Game game;
    [SerializeField] private Player player;
    public event Action PlayerReachedFinish;
    private Platform[] platforms;
    private int currentPlatform = 0;
    private void Awake()
    {
        platforms = levelConfig.Platforms;
    }
    private void OnEnable()
    {
        player.PathMover.FinishedPath += CheckPlatform;
        game.GameStarted += PlayerMoveToNextPlatform;
        foreach (var p in platforms)
        {
            p.AllEnemiesDiedOnPlatform += TryMoveToNextPlatform;
        }
    }

    private void OnDisable()
    {
        player.PathMover.FinishedPath -= CheckPlatform;
        game.GameStarted -= PlayerMoveToNextPlatform;
        foreach (var p in platforms)
        {
            p.AllEnemiesDiedOnPlatform -= TryMoveToNextPlatform;
        }
    }
    public Path GetPathToNextPlatform()
    {
        return platforms[currentPlatform].Path;
    }
    private void PlayerMoveToNextPlatform()
    {
        player.PathMover.Path = GetPathToNextPlatform();
    }
    private void TryMoveToNextPlatform(Platform platform)
    {
        if (platforms[currentPlatform] == platform)
            PlayerMoveToNextPlatform();
    }
    private void CheckPlatform()
    {
        currentPlatform++;
        if (platforms[currentPlatform].Type == PlatformType.Finish)
        {
            PlayerReachedFinish?.Invoke();
            return;
        }
        if (platforms[currentPlatform].Clear)
        {
            PlayerMoveToNextPlatform();
        }
    }
}
