namespace Examples.Postprocessing.PP1
{
    using UnityEngine;
    using UnityEditor;

    public class SimplePostProcesser : AssetPostprocessor
    {
        void OnPreprocessAsset()
        {
            Debug.Log("Called Before Processing an asset");
        }

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths, bool didDomainReload)
        {
            Debug.Log("Called After Processing an asset");

            foreach (var importedAsst in importedAssets)
            {
                foreach (string importAsset in importedAssets)
                {
                    Debug.Log("Reimported Asset: " + importAsset);
                }

                foreach (string deletedAsset in deletedAssets)
                {
                    Debug.Log("Deleted Asset: " + deletedAsset);
                }

                for (int i = 0; i < movedAssets.Length; i++)
                {
                    Debug.Log("Moved Asset: " + movedAssets[i] + " from: " + movedFromAssetPaths[i]);
                }

                if (didDomainReload)
                {
                    Debug.Log("Domain has been reloaded");
                }
            }
        }
    }

    /*
     * Links:
     * AssetPostprocessor: https://docs.unity3d.com/ScriptReference/AssetPostprocessor.html
     * OnPreprocessAsset: https://docs.unity3d.com/ScriptReference/AssetPostprocessor.OnPreprocessAsset.html
     * 
     * OnPostprocessAllAssets: https://docs.unity3d.com/ScriptReference/AssetPostprocessor.OnPostprocessAllAssets.html
     */
}
