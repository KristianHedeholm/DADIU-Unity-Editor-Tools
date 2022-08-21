namespace Examples.CustomInspectors.CI1
{
    using UnityEngine;
    using UnityEditor;

    [CustomEditor(typeof(Player))]
    public class PlayerCustomInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space(5);

            if(GUILayout.Button("Click Me"))
            {
                Debug.Log("Yay you clicked me!");
            }
        }
    }

    /*
     * Links:
     * CustomEditor: https://docs.unity3d.com/ScriptReference/CustomEditor.html
     * DrawDefaultInspector: https://docs.unity3d.com/ScriptReference/Editor.DrawDefaultInspector.html
     * EditorGUILayout.Space: https://docs.unity3d.com/ScriptReference/EditorGUILayout.Space.html
     * GUILayout.Button: https://docs.unity3d.com/ScriptReference/GUILayout.Button.html
     */
}
