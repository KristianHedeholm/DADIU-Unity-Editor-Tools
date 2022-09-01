namespace Examples.ScriptableObjects.SO4
{
    using UnityEngine;
    using UnityEditor;
    using System.Collections.Generic;
    using System.IO;

    [CustomEditor(typeof(SaveObject))]
    public class SaveObjectCustomInspector : Editor
    {
        private const string scriptableObjectsFolderPath = "Assets/Scripts/2. Scriptable Objects/SO4 Save Scriptable Object as Runtime/ScriptableObjects/";
        private const string scriptableObjectDefaultName = "Save Scriptable Object Data ";
        private const string scritableObjectExtension = ".asset";

        private List<string> scriptableObjectNames = new List<string>();

        private SerializedProperty intValue;

        private void OnEnable()
        {
            intValue = serializedObject.FindProperty("intValue");
            UpdateListOfAssetNames();
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space(5);

            if(GUILayout.Button("Save Int Value To Scritable Object"))
            {
                SaveValueToScriptableObject();
            }
        }

        private void UpdateListOfAssetNames()
        {
            scriptableObjectNames.Clear();
            string[] guids = AssetDatabase.FindAssets($"t:{typeof(SaveableScriptableObject)}", new string[] { scriptableObjectsFolderPath });
            foreach (var guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                string filename = Path.GetFileNameWithoutExtension(path);
                scriptableObjectNames.Add(filename);
            }
        }

        private void SaveValueToScriptableObject()
        {
            SaveableScriptableObject cameraDataScriptableObject = ScriptableObject.CreateInstance<SaveableScriptableObject>();
            cameraDataScriptableObject.IntValue = intValue.intValue;

            string uniqueFilename = ObjectNames.GetUniqueName(scriptableObjectNames.ToArray(), scriptableObjectDefaultName);
            AssetDatabase.CreateAsset(cameraDataScriptableObject, $"{scriptableObjectsFolderPath}{uniqueFilename}{scritableObjectExtension}");
            scriptableObjectNames.Add(uniqueFilename);
        }
    }
}
