using System;
using UnityEngine;

public abstract class ProjectileMover : MonoBehaviour
{
    [SerializeField, Range(0, 100)] protected float speed = 5;
    [SerializeField] protected Rigidbody rb;
    [SerializeField, Range(0, 100)] private float lifeTime = 100;
    private float deathTime;
    public event Action PathEnded;
    private void OnEnable()
    {
        ResetMover();
        deathTime = Time.time + lifeTime;
    }

    private void Update()
    {
        if (deathTime < Time.time)
            PathEnded?.Invoke();
        UpdateMovement();
    }
    private void FixedUpdate()
        => FixedUpdateMovement();

    protected abstract void UpdateMovement();
    protected abstract void FixedUpdateMovement();
    protected abstract void ResetMover();
}