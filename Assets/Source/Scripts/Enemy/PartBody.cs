using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PartBody : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private Rigidbody body;
    private Collider coll;
    private void Start()
    {
        body = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    public void IteractWithProjectile(Vector3 direction)
    {
        enemy.Animator.enabled = false;
        body.AddForce(direction, ForceMode.VelocityChange);
    }
}
