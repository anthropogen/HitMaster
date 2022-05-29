using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Path))]
public class PathEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Collect Points"))
        {
            var path = (Path)target;
            var points = path.GetComponentsInChildren<Waypoint>();
            var type = path.GetType();
            var property = type.GetProperty("Waypoints");
            property.SetValue(path, points);
            EditorUtility.SetDirty(target);
        }
    }
}
