using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Projectile : MonoBehaviour
{
    [SerializeField, Range(0, 1000)] private float iteractForce = 5;
    [SerializeField, Range(0, 100)] private float damage;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private ProjectileMover mover;

    private void OnEnable()
    {
        mover.PathEnded += DisableProjectile;
    }
    private void OnDisable()
    {
        mover.PathEnded -= DisableProjectile;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PartBody partBody))
        {
            var direction = (collision.gameObject.transform.position - transform.position).normalized;

            partBody.IteractWithProjectile(direction * iteractForce, damage);
        }
        DisableProjectile();
    }
    private void Reset()
    {
        if (mover == null)
            Debug.LogError($"Projectile {name} doesn't have mover, need to add mover");
    }
    public void Init(Vector3 point)
        => mover.Init(point);

    private void DisableProjectile()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
