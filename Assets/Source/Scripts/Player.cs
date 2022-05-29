using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public PathMover PathMover { get; private set; }
    [field: SerializeField] public Gunner Gunner { get; private set; }
}
