using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SphereScript))]
public class SphereEditor : Editor {

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        SphereScript sphere = (SphereScript)target;
        GUILayout.Label("Oscillates around a base size.");
        sphere.baseSize= EditorGUILayout.Slider("Size",sphere.baseSize, .1f, 2f);

        sphere.transform.localScale = Vector3.one * sphere.baseSize;
    }

}
