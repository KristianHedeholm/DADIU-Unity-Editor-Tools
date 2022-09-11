namespace Examples.Postprocessing.PP2
{
    using UnityEditor;
    using System.IO;

    public class ScriptChecker : AssetPostprocessor
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
                    MonoImporter monoImporter = AssetImporter.GetAtPath(importedAsst) as MonoImporter;
                    string filename = Path.GetFileNameWithoutExtension(monoImporter.assetPath);

                    bool startWithUpperCaseLetter = char.IsUpper(filename[0]);
                    if (!startWithUpperCaseLetter)
                    {
                        string newFilename = ForceFirstLetterToUpperCase(filename);
                        string text = File.ReadAllText(monoImporter.assetPath);
                        text = text.Replace(filename, newFilename);
                        File.WriteAllText(monoImporter.assetPath, text);
                        filename = newFilename;
                    }

                    if (!importedAsst.Contains(scriptPath) || !startWithUpperCaseLetter)
                    {
                        string newPath = $@"{scriptPath}/{filename}{cSharpExtension}";
                        AssetDatabase.MoveAsset(monoImporter.assetPath, newPath);
                    }
                }
            }
        }

        private static string ForceFirstLetterToUpperCase(string inputValue)
        {
            return char.ToUpper(inputValue[0]) + inputValue.Substring(1);
        }
    }
}
