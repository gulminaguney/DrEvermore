using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FloorTilerFix))]
public class FloorTilerFixEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        FloorTilerFix script = (FloorTilerFix)target;
        if (GUILayout.Button("🧱 Generate Floor Grid"))
        {
            script.Generate();
        }
    }
}

