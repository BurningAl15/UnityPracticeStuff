using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomInspector))]
public class CubeEditor : Editor {

    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();
        //Target is a variable that references to an object that haves a specific script in it
        CustomInspector inspect = (CustomInspector) target;

        //Shows everything between begin and end into a line
        GUILayout.BeginHorizontal();

        
            
            if (GUILayout.Button("Generate Color"))
            {
                inspect.GenerateColor();
            }

            if (GUILayout.Button("Reset Color"))
            {
                inspect.Reset();
            }

        GUILayout.EndHorizontal();

    }


}
