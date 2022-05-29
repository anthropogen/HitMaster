using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PathMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField, Range(0, 100)] private float turnSpeed = 5f;
    private Path path;
    private int currentWaypoint = 0;
    private float sqrStopDistance;
    public event Action FinishedPath;
    public Path Path { set { path = value; } }
    private void Start()
    {
        sqrStopDistance = agent.stoppingDistance * agent.stoppingDistance;
    }
    private void Update()
    {
        if (path == null) return;
        agent.SetDestination(path[currentWaypoint].transform.position);
        if (ReachedWayPoint(path[currentWaypoint].Point))
        {
            if (CanSetNextPoint())
            {
                currentWaypoint++;
            }
            else
            {
                StartCoroutine(RotateToForward());
                currentWaypoint = 0;
                path = null;
                FinishedPath?.Invoke();
            }
        }
    }

    private bool CanSetNextPoint()
        => (currentWaypoint + 1 < path.Lenght);

    private bool ReachedWayPoint(Vector3 point)
        => Vector3.SqrMagnitude(transform.position - point) > sqrStopDistance;

    private IEnumerator RotateToForward()
    {
        Quaternion target = Quaternion.Euler(0, 0, 0);
        while (transform.rotation != target)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * turnSpeed);
            yield return null;
        }
    }
}
