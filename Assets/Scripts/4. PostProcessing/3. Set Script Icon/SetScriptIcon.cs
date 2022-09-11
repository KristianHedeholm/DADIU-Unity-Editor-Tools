namespace Examples.Postprocessing.PP3
{
    using UnityEngine;
    using UnityEditor;

    public class SetScriptIcon : AssetPostprocessor
    {
        private const string cSharpExtension = ".cs";
        private const string PlayerScriptsFolderName = "PlayerScripts";
        private const string EnemyScriptsFolderName = "EnemyScripts";

        private const string PlayerScriptsIconPath = "Assets/Scripts/4. PostProcessing/3. Set Script Icon/Icons/PlayerScriptIcon.png";
        private const string EnemyScriptsIconPath = "Assets/Scripts/4. PostProcessing/3. Set Script Icon/Icons/EnemyScriptIcon.png";

        private void OnPreprocessAsset()
        {
            if(assetImporter is MonoImporter)
            {
                MonoImporter monoImporter = assetImporter as MonoImporter;
                if(monoImporter.assetPath.Contains(PlayerScriptsFolderName))
                {
                    Texture2D playerScriptsIcon = AssetDatabase.LoadAssetAtPath<Texture2D>(PlayerScriptsIconPath);
                    SetIconOnScript(monoImporter, playerScriptsIcon);
                }

                if(monoImporter.assetPath.Contains(EnemyScriptsFolderName))
                {
                    Texture2D enemyScriptsIcon = AssetDatabase.LoadAssetAtPath<Texture2D>(EnemyScriptsIconPath);
                    SetIconOnScript(monoImporter, enemyScriptsIcon);
                }
            }
        }

        private static void SetIconOnScript(MonoImporter monoImporter, Texture2D texture2D)
        {
            monoImporter.SetIcon(texture2D);
            monoImporter.SaveAndReimport();
        }
    }

    /*
     * Link:
     * OnPreprocessAsset:  https://docs.unity3d.com/ScriptReference/AssetPostprocessor.OnPreprocessAsset.html
     * AssetPostprocessor.assetImporter: https://docs.unity3d.com/ScriptReference/AssetPostprocessor-assetImporter.html
     * 
     * MonoImporter: https://docs.unity3d.com/ScriptReference/MonoImporter.html
     * MonoImporter.SetIcon: https://docs.unity3d.com/ScriptReference/MonoImporter.SetIcon.html
     * 
     * AssetImporter.SaveAndReimport: https://docs.unity3d.com/ScriptReference/AssetImporter.SaveAndReimport.html
     * Check out: https://github.com/halak/unity-editor-icons
     */
}
