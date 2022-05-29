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
    }
    private void OnDisable()
    {
        game.GameStarted -= PlayerMoveToNextPlatform;
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
}
