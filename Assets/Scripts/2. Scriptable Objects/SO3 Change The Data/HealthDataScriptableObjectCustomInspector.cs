namespace Examples.ScriptableObjects.SO3
{
    using UnityEngine;
    using UnityEditor;

    [CustomEditor(typeof(HealthDataScriptableObject))]
    public class HealthDataScriptableObjectCustomInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space(5);

            if (GUILayout.Button("Set Current Health To Start Health"))
            {
                HealthDataScriptableObject healthDataScriptableObject = target as HealthDataScriptableObject;
                healthDataScriptableObject.ResetToStartHealth();
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}
