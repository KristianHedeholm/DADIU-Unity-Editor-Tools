namespace Examples.CustomInspectors.CI3
{
    using UnityEngine;
    using UnityEditor;

    [CustomEditor(typeof(ChestItem))]
    public class ChestItemCustomInspector : Editor
    {
        private SerializedProperty Preview;
        private SerializedProperty Description;
        private SerializedProperty Cost;

        private void OnEnable()
        {
            Preview = serializedObject.FindProperty("Preview");
            Description = serializedObject.FindProperty("Description");
            Cost = serializedObject.FindProperty("Cost");
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space(5);

            serializedObject.Update();

            if(GUILayout.Button("Add This Item to Player Inventory"))
            {
                ChestItem chestItem = target as ChestItem;
                GameObject gameObject = chestItem.gameObject;
                if(gameObject.TryGetComponent<PlayerCI3>(out PlayerCI3 player))
                {
                    PlayerCustomInspector playerCustomInspector = Editor.CreateEditor(player, typeof(PlayerCustomInspector)) as PlayerCustomInspector;
                    Texture2D previewTexture = Preview.objectReferenceValue as Texture2D;
                    playerCustomInspector.AddIventoryItem(previewTexture, Description.stringValue, Cost.intValue);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
