namespace Examples.CustomEditorExtensions.CEE2
{
    using UnityEngine;
    using UnityEditor;

    public class SimpleEditorWindow : EditorWindow
    {
        [MenuItem("Tools/My Editor Window/Simple Editor Window")]
        private static void CreateWindow()
        {
            var window = GetWindow<SimpleEditorWindow>("Simple Editor Window");
        }

        private void OnGUI()
        {
            if(GUILayout.Button("Click Me"))
            {
                Debug.Log("Yay you clicked me!");
            }
        }
    }

    //EditorWindow.OnGUI()
    /*
    * Links
    * EditorWindow: https://docs.unity3d.com/2022.1/Documentation/ScriptReference/EditorWindow.html
    * EditorWindow.GetWindow: https://docs.unity3d.com/2022.1/Documentation/ScriptReference/EditorWindow.GetWindow.html
    * 
    * EditorWindow.OnGUI: https://docs.unity3d.com/2022.1/Documentation/ScriptReference/EditorWindow.OnGUI.html
    */
}
