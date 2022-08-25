namespace Examples.CustomEditorExtensions.CEE2
{
    using UnityEngine;
    using UnityEditor;

    public class AssetHandlingWindow : EditorWindow
    {
        private const string prefabSearchFilter = " t:gameobject";
        private readonly string[] prefabSearchFolder 
            = new string[] { "Assets/Scripts/4. Custom Editor Extensions/CEE3 Handle Assets In the Project/Prefabs" };

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
}
