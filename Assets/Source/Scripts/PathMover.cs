using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PathMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
}
