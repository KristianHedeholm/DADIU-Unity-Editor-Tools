namespace Examples.CustomEditorExtensions.CEE5
{
    using UnityEngine;
    using UnityEditor;
    using UnityEditor.SceneManagement;

    [InitializeOnLoad]
    public static class LoadOnStartOfProject
    {
        private static bool showThisExample = false;

        static LoadOnStartOfProject()
        {
            if(showThisExample)
            {
                EditorApplication.hierarchyChanged += OnHierarchyChanged;
                EditorSceneManager.sceneOpening += OnSceneOpning;
                EditorApplication.quitting += OnQuitting;
            }
        }

        public static void OnHierarchyChanged()
        {
            Debug.Log("Something changed in the Hierrarchy");
        }

        public static void OnSceneOpning(string path, OpenSceneMode openSceneMode)
        {
            Debug.Log($"Opning scene at path: {path} in mode: {openSceneMode}");
        }

        public static void OnQuitting()
        {
            Debug.Log("Quitting the Editor");
            EditorApplication.hierarchyChanged -= OnHierarchyChanged;
            EditorSceneManager.sceneOpening -= OnSceneOpning;
            EditorApplication.quitting -= OnQuitting;
        }
    }
}
