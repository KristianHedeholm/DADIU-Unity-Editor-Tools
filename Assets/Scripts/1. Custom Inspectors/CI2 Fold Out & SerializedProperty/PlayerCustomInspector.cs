namespace Examples.CustomInspectors.CI2
{
    using UnityEditor;

    [CustomEditor(typeof(PlayerCI2))]
    public class PlayerCustomInspector : Editor
    {
        private SerializedProperty Health;
        private SerializedProperty armo;

        private SerializedProperty numberOfGuns;

        private bool showHealth;
        private bool showArmo;

        private void OnEnable()
        {
            Health = serializedObject.FindProperty("Health");
            armo = serializedObject.FindProperty("armo");

            // numberOfGuns = serializedObject.FindProperty("numberOfGuns"); // this will not work since the field is not Serialized in the Player class!
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            showHealth = EditorGUILayout.Foldout(showHealth, "Show Health");
            if(showHealth)
            {
                Health.intValue = EditorGUILayout.IntField("Health", Health.intValue);
            }

            showArmo = EditorGUILayout.Foldout(showArmo, "Show Armo");
            if(showArmo)
            {
                EditorGUILayout.PropertyField(armo);
            }

            // this will not work since the field is not Serialized in the Player class!
            // EditorGUILayout.PropertyField(numberOfGuns);

            serializedObject.ApplyModifiedProperties();
        }
    }

    /*
     * Links:
     * SerializedObject: https://docs.unity3d.com/ScriptReference/SerializedObject.html
     * SerializedProperty: https://docs.unity3d.com/ScriptReference/SerializedProperty.html
     * 
     * SerializedObject.FindProperty: https://docs.unity3d.com/ScriptReference/SerializedObject.FindProperty.html
     * SerializedObject.Update: https://docs.unity3d.com/ScriptReference/SerializedObject.Update.html
     * 
     * EditorGUILayout.Foldout: https://docs.unity3d.com/ScriptReference/EditorGUILayout.Foldout.html
     * EditorGUILayout.IntField: https://docs.unity3d.com/ScriptReference/EditorGUILayout.IntField.html
     * 
     * EditorGUILayout.PropertyField: https://docs.unity3d.com/ScriptReference/EditorGUILayout.PropertyField.html
     * SerializedObject.ApplyModifiedProperties: https://docs.unity3d.com/ScriptReference/SerializedObject.ApplyModifiedProperties.html
     */
}
