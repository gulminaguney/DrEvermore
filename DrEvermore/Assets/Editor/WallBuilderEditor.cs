using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WallBuilder))]
public class WallBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        WallBuilder script = (WallBuilder)target;
        if (GUILayout.Button("🧱 Build Wall Grid"))
        {
            script.BuildWalls();
        }
    }
}
