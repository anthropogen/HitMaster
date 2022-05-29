using UnityEditor;
using UnityEngine;
using System.Reflection;

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
            var property = type.GetField("waypoints", BindingFlags.Instance | BindingFlags.NonPublic);
            property.SetValue(path, points);
            EditorUtility.SetDirty(target);
        }
    }
}
