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
}
