namespace Examples.CustomEditorExtensions.CEE6
{
    using System.IO;
    using UnityEditor;
    using UnityEngine;

    public static class CopyPrefabs 
    {
        private const string parentPath = "Assets/Scripts/4. Custom Editor Extensions/CEE6 ProgressBar";
        private const string newPrefabFolderName = "NewPrefabs";

        [MenuItem("Tools/Menu Item Copy Prefabs")]
        private static void CopyPrefabsToNewFolder()
        {
            if(!AssetDatabase.IsValidFolder($"{parentPath}/{newPrefabFolderName}"))
            {
                AssetDatabase.CreateFolder(parentPath, newPrefabFolderName);
            }

            var guids = AssetDatabase.FindAssets("t:gameobject", new string[] { parentPath});
            var totalGuids = guids.Length;
            var numberOfCopiedGameobjects = 0;
            foreach (var guid in guids)
            {
                var oldPath = AssetDatabase.GUIDToAssetPath(guid);
                var filename = Path.GetFileName(oldPath);
                var newPath = $"{parentPath}/{newPrefabFolderName}/{filename}";

                FileUtil.CopyFileOrDirectory(oldPath, newPath);

                var progress = (float)numberOfCopiedGameobjects / totalGuids;
                EditorUtility.DisplayProgressBar("Coping Game Object to New Prefabs Folder", $"Copying asset: {filename}", progress);
                numberOfCopiedGameobjects++;
            }

            AssetDatabase.Refresh();
            Debug.Log($"Done copying {guids.Length} Game Objects");
            EditorUtility.ClearProgressBar();
        }

    }

    /*
     * Links:
     * AssetDatabase.IsValidFolder: https://docs.unity3d.com/ScriptReference/AssetDatabase.IsValidFolder.html
     * AssetDatabase.CreateFolder: https://docs.unity3d.com/ScriptReference/AssetDatabase.CreateFolder.html
     * 
     * FileUtil.CopyFileOrDirectory: https://docs.unity3d.com/ScriptReference/FileUtil.CopyFileOrDirectory.html
     * EditorUtility.DisplayProgressBar: https://docs.unity3d.com/ScriptReference/EditorUtility.DisplayProgressBar.html
     * 
     * AssetDatabase.Refresh: https://docs.unity3d.com/ScriptReference/AssetDatabase.Refresh.html
     * EditorUtility.ClearProgressBar: https://docs.unity3d.com/ScriptReference/EditorUtility.ClearProgressBar.html
     */
}
