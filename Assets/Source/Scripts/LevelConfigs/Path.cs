using UnityEditor;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Waypoint[] Waypoints { get; private set; }

    private void OnDrawGizmos()
    {
        if (Waypoints == null) return;
        if (Waypoints.Length < 2) return;
        Gizmos.color = Color.yellow;
        for (int i = 1; i < Waypoints.Length; i++)
        {
            Handles.color = Color.black;
            Gizmos.DrawLine(Waypoints[i - 1].Point, Waypoints[i].Point);
            Handles.Label(GetLabelPos(Waypoints[i - 1].Point), $"{i - 1}");
        }
        Handles.Label(GetLabelPos(Waypoints[Waypoints.Length - 1].Point), $"{Waypoints.Length - 1}");
    }
    private Vector3 GetLabelPos(Vector3 pos)
    {
        return new Vector3(pos.x, pos.y + .5f, pos.z);
    }
}
