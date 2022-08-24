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
}
