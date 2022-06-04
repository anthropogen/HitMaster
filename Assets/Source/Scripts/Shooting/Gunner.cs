using System;
using UnityEngine;

public class Gunner : MonoBehaviour
{
    [SerializeField] private Gun gun;
    [SerializeField] private GameFactory factory;
    [SerializeField, Range(0, 100)] float pointDistance;
    [SerializeField, Range(0, 180)] private float maxShootAngle;
    [SerializeField] private PlayerAnimator animator;
    [SerializeField] private AnimationEventReceiver eventReceiver;
    private Camera cam;
    private Vector3 targetPoint;
    public event Action<Projectile> InitedProjectile;
    private void OnEnable()
    {
        eventReceiver.Shot += Shoot;
    }
    private void OnDisable()
    {
        eventReceiver.Shot -= Shoot;
    }
    private void Start()
    {
        cam = Camera.main;
        animator.SetAnimator(gun.AnimController);
        InitedProjectile?.Invoke(gun.Projectile);
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 25, Color.red);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point;
            if (Physics.Raycast(ray, out hit))
            {
                point = hit.point;
            }
            else
            {
                point = ray.GetPoint(pointDistance);
            }
            var angle = Vector3.SignedAngle(point - transform.position, transform.forward, Vector3.up);
            if ((Mathf.Abs(angle)) > maxShootAngle)
                return;
            targetPoint = point;
            animator.Shoot();
        }
    }

    public void Shoot()
    {
        var direction = targetPoint - gun.ShootPos;
        Quaternion rotation = Quaternion.LookRotation(direction);
        var projectile = factory.BulletPool.GetAt(gun.ShootPos, rotation);
        projectile.Init(targetPoint);
    }
}
