using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PartBody : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private Rigidbody body;
    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    public void IteractWithProjectile(Vector3 direction)
    {
        enemy.Death();
        body.AddForce(direction, ForceMode.VelocityChange);
    }
}
