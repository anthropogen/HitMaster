using UnityEngine;
public class GameFactory : MonoBehaviour
{
    [SerializeField] private Gunner gunner;
    public ObjectPool<Projectile> BulletPool { get; private set; }
    private void OnEnable()
    {
        gunner.InitedProjectile += OnInitedProjectile;
    }

    private void OnDisable()
    {
        gunner.InitedProjectile -= OnInitedProjectile;
    }
    private void OnInitedProjectile(Projectile projectile)
    {
        BulletPool = new ObjectPool<Projectile>(projectile, 10, transform);
    }
}
