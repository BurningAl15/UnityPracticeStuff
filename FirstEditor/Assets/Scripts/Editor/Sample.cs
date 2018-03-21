using UnityEngine;
using UnityEditor;

public class Sample : EditorWindow {

    string myString = "Hello, World!";

    Color color;

    //Creates a window
    [MenuItem("Window/Colorizer")]
    public static void ShowWindow()
    {
        GetWindow<Sample>("Colorizer");
        
    }

    private void OnGUI()
    {
        //Window code
        GUILayout.Label("Color the Selected objects", EditorStyles.boldLabel);

        color=EditorGUILayout.ColorField("Color",color);

        if(GUILayout.Button("Colorize!"))
        {
            Colorize();
        }

         
    }

    void Colorize()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }


}

