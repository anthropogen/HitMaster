using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshSurface))]
public class LevelConfig : MonoBehaviour
{
    [field: SerializeField] public Platform[] Platforms { get; private set; }
}
