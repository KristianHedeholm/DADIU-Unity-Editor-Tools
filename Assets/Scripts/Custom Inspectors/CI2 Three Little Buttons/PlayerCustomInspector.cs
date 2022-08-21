namespace Examples.CustomInspectors.CI2
{
    using UnityEngine;
    using UnityEditor;

    [CustomEditor(typeof(Player))]
    public class PlayerCustomInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GUILayout.Space(5);

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Button 1"))
            {
                Debug.Log("You clicked on Button 1");
            }

            if (GUILayout.Button("Button 2"))
            {
                Debug.Log("You clicked on Button 2");
            }

            if (GUILayout.Button("Button 3"))
            {
                Debug.Log("You clicked on Button 3");
            }

            EditorGUILayout.EndHorizontal();
        }
    }

    /*
     * Links:
     * EditorGUILayout.BeginHorizontal: https://docs.unity3d.com/ScriptReference/EditorGUILayout.BeginHorizontal.html
     * EditorGUILayout.EndHorizontal: https://docs.unity3d.com/ScriptReference/EditorGUILayout.EndHorizontal.html
     * 
     * See also:
     * EditorGUILayout.BeginVertical: https://docs.unity3d.com/ScriptReference/EditorGUILayout.BeginVertical.html
     * EditorGUILayout.EndVertical: https://docs.unity3d.com/ScriptReference/EditorGUILayout.EndVertical.html
     */
}
