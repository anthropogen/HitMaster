using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;
    [field: SerializeField] public Path Path { get; private set; }
}
