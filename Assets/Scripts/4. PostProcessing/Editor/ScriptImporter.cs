namespace Examples.Postprocessing.PP1
{
    using UnityEditor;
    using System.IO;

    public class ScriptImporter : AssetPostprocessor
    {
        private const string cSharpExtension = ".cs";
        private const string scriptPath = "Assets/Scripts";

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths, bool didDomainReload)
        {
            foreach (var importedAsst in importedAssets)
            {
                string fileExtension = Path.GetExtension(importedAsst);
                if (fileExtension.Equals(cSharpExtension))
                {
                    if (!importedAsst.Contains(scriptPath))
                    {
                        MonoImporter monoImporter = AssetImporter.GetAtPath(importedAsst) as MonoImporter;
                        string filename = Path.GetFileName(monoImporter.assetPath);
                        string newPath = $@"{scriptPath}/{filename}";
                        AssetDatabase.MoveAsset(monoImporter.assetPath, newPath);
                    }
                }
            }
        }
    }
}
