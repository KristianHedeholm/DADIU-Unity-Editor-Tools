namespace Examples.CustomEditorExtensions.CEE3
{
    using UnityEngine;
    using UnityEditor;

    public class AssetHandlingWindow : EditorWindow
    {
        private const string prefabSearchFilter = " t:gameobject";
        private readonly string[] prefabSearchFolder 
            = new string[] { "Assets/Scripts/3. Custom Editor Extensions/CEE3 Handle Assets In the Project/Prefabs" };

        private GameObject selectedGameOBject;

        [MenuItem("Tools/My Editor Window/Asset Handling Window")]
        private static void CreateWindow()
        {
            var window = GetWindow<AssetHandlingWindow>("Asset Handling Window");
        }

        private void OnGUI()
        {
            selectedGameOBject = EditorGUILayout.ObjectField("Selected Game Object", selectedGameOBject, typeof(GameObject), false) as GameObject;

            EditorGUILayout.Space(5);

            if (GUILayout.Button("Look for PrefabA"))
            {
                selectedGameOBject = LoadPrefabWithName("PrefabA");
            }

            EditorGUILayout.Space(5);

            if (GUILayout.Button("Look for PrefabB"))
            {
                selectedGameOBject = LoadPrefabWithName("PrefabB");
            }
        }

        private GameObject LoadPrefabWithName(string name)
        {
            string[] guids = AssetDatabase.FindAssets(name + prefabSearchFilter, prefabSearchFolder);

            if(guids.Length == 0)
            {
                return null;
            }

            string path = AssetDatabase.GUIDToAssetPath(guids[0]);
            GameObject gameObject = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            return gameObject;
        }
    }

    /*
    * Links
    * EditorGUILayout.ObjectField: https://docs.unity3d.com/ScriptReference/EditorGUILayout.ObjectField.html
    * AssetDatabase: https://docs.unity3d.com/ScriptReference/AssetDatabase.html
    * 
    * AssetDatabase.FindAssets: https://docs.unity3d.com/ScriptReference/AssetDatabase.FindAssets.html
    * GUIDs in Unity: https://unityatscale.com/unity-meta-file-guide/understanding-meta-files-and-guids/ 
    * 
    * AssetDatabase.GUIDToAssetPath: https://docs.unity3d.com/ScriptReference/AssetDatabase.GUIDToAssetPath.html
    * AssetDatabase.LoadAssetAtPath: https://docs.unity3d.com/ScriptReference/AssetDatabase.LoadAssetAtPath.html
    */
}
