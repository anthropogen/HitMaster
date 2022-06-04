using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform shootPosition;
    [field: SerializeField] public Projectile Projectile { get; private set; }
    [field: SerializeField] public AnimatorOverrideController AnimController { get; private set; }
    public Vector3 ShootPos => shootPosition.position;
}
