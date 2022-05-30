using System;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private Platform[] platforms;
    [SerializeField] private Game game;
    [SerializeField] private Player player;
    private int currentPlatform = 0;
    private void OnEnable()
    {
        game.GameStarted += PlayerMoveToNextPlatform;
        foreach (var p in platforms)
        {
            p.AllEnemiesDiedOnPlatform += TryMoveToNextPlatform;
        }
    }


    private void OnDisable()
    {
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
        currentPlatform++;
    }
    private void TryMoveToNextPlatform(Platform platform)
    {
        if (platforms[currentPlatform] == platform)
            PlayerMoveToNextPlatform();
    }
}
