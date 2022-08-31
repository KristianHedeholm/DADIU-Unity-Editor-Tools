namespace Examples.CustomEditorExtensions.CEE4
{
    using UnityEngine;
    using UnityEditor;
    using System.Collections.Generic;
    using System.IO;
    using UnityEditor.SceneManagement;

    public class FindAssetsInScenes : EditorWindow
    {
        private const string sceneSearchFilter = " t:scene";
        private readonly string[] sceneSearchFolder
            = new string[] { "Assets/Scripts/4. Custom Editor Extensions/CEE4 Find Assets In Scenes/Scenes" };

        private Dictionary<string, string> scenes = new Dictionary<string, string>();

        private Vector2 scrollPosition = Vector2.zero;
        private RareItem[] rareItems;
        private int rareItemIndex = 0;
        private bool showNextButton = false;
        private string currentState;

        [MenuItem("Tools/My Editor Window/Find Assets In Scenes Window")]
        private static void CreateWindow()
        {
            var window = GetWindow<FindAssetsInScenes>("Find Assets In Scenes Window");
        }

        private void OnEnable()
        {
            scenes.Clear();
            string[] sceneGUIDs = AssetDatabase.FindAssets(sceneSearchFilter, sceneSearchFolder);
            foreach (string sceneGUID  in sceneGUIDs)
            {
                string scenePath = AssetDatabase.GUIDToAssetPath(sceneGUID);
                string sceneName = Path.GetFileNameWithoutExtension(scenePath);

                scenes.Add(sceneName, scenePath);
            }

            EditorApplication.playModeStateChanged += PlayModeStateChange;
        }

        private void OnDisable()
        {
            EditorApplication.playModeStateChanged -= PlayModeStateChange;
        }

        private void PlayModeStateChange(PlayModeStateChange state)
        {
            switch (state)
            {
                case UnityEditor.PlayModeStateChange.EnteredEditMode:
                    currentState = "You are in edit mode";
                    break;

                case UnityEditor.PlayModeStateChange.ExitingEditMode:
                    break;

                case UnityEditor.PlayModeStateChange.EnteredPlayMode:
                    currentState = "You are in play mode";
                    break;

                case UnityEditor.PlayModeStateChange.ExitingPlayMode:
                    break;
            }
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Scenes In Project: ");
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Height(150));
            foreach (KeyValuePair<string, string> sceneItem in scenes)
            {
                if(GUILayout.Button($"Open {sceneItem.Key}"))
                {
                    if (EditorApplication.isPlaying)
                    {
                        return;
                    }

                    if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                    {
                        return;
                    }

                    showNextButton = false;
                    EditorSceneManager.OpenScene(sceneItem.Value);
                }

                EditorGUILayout.Space(10);
            }
            EditorGUILayout.EndScrollView();

            EditorGUILayout.Space(5);

            if(GUILayout.Button("Find Rare Items In Scene"))
            {
                rareItems = FindObjectsOfType<RareItem>();
                if(rareItems.Length == 0)
                {
                    Debug.Log("No Rare Items found");
                }

                rareItemIndex = 0;
                HighlightGameObject(rareItemIndex);
                showNextButton = rareItems.Length > 1;
            }

            EditorGUILayout.Space(5);

            if (showNextButton)
            {
                if (GUILayout.Button("Find Next"))
                {
                    rareItemIndex = (1 + rareItemIndex) % rareItems.Length;
                    HighlightGameObject(rareItemIndex);
                }
            }

            EditorGUILayout.Space(5);

            EditorGUILayout.LabelField(currentState);
        }

        private void HighlightGameObject(int index)
        {
            EditorGUIUtility.PingObject(rareItems[index].gameObject);
            Selection.activeObject = rareItems[index].gameObject;
        }
    }

    /*
    * Links
    * Path.GetFileNameWithoutExtension: https://docs.microsoft.com/en-us/dotnet/api/system.io.path.getfilenamewithoutextension?view=net-6.0
    * EditorApplication.playModeStateChanged: https://docs.unity3d.com/ScriptReference/EditorApplication-playModeStateChanged.html
    * 
    * EditorApplication.isPlaying: https://docs.unity3d.com/ScriptReference/EditorApplication-isPlaying.html
    * EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo: https://docs.unity3d.com/ScriptReference/SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo.html
    * 
    * EditorSceneManager.OpenScene: https://docs.unity3d.com/ScriptReference/SceneManagement.EditorSceneManager.OpenScene.html
    * EditorGUIUtility.PingObject: https://docs.unity3d.com/ScriptReference/EditorGUIUtility.PingObject.html
    */
}
