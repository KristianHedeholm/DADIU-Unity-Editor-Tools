namespace Examples.CustomInspectors.CI3
{
    using UnityEngine;
    using UnityEditor;

    [CustomEditor(typeof(PlayerCI3))]
    public class PlayerCustomInspector : Editor
    {
        private SerializedProperty Inventory;

        private Vector2 scrollPosition = Vector2.zero;

        private void OnEnable()
        {
            Inventory = serializedObject.FindProperty("Inventory");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("List of Inventory Items");

            EditorGUILayout.Space(5);

            EditorGUIUtility.labelWidth = 75;
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Height(200));
            int numberOfInventoryItems = Inventory.arraySize;
            for (int i = 0; i < numberOfInventoryItems; i++)
            {
                SerializedProperty inventoryItemSP = Inventory.GetArrayElementAtIndex(i);
                SerializedProperty previewSP = inventoryItemSP.FindPropertyRelative("Preview");
                SerializedProperty descriptionSP = inventoryItemSP.FindPropertyRelative("Description");
                SerializedProperty costSP = inventoryItemSP.FindPropertyRelative("Cost");

                EditorGUILayout.BeginHorizontal();

                Texture2D preview = previewSP.objectReferenceValue as Texture2D;
                preview = EditorGUILayout.ObjectField("Preview", preview, typeof(Texture2D), false) as Texture2D;
                previewSP.objectReferenceValue = preview;

                EditorGUILayout.Space(5);

                EditorGUILayout.PropertyField(descriptionSP);

                EditorGUILayout.Space(5);

                EditorGUILayout.IntField("Cost", costSP.intValue, GUILayout.Width(125));

                EditorGUILayout.EndHorizontal();

                EditorGUILayout.Space(10);
            }

            EditorGUILayout.EndScrollView();

            if(GUILayout.Button("Add Iventory Item"))
            {
                AddIventoryItem(Texture2D.whiteTexture, "this is a test", 9001);
            }
        }

        public void AddIventoryItem(Texture2D preview, string description, int cost)
        {
            InventoryItem inventoryItem = new InventoryItem()
            {
                Preview = preview,
                Description = description,
                Cost = cost,
            };
            int lastIndex = Inventory.arraySize;
            Inventory.InsertArrayElementAtIndex(lastIndex);
            SerializedProperty inventoryItemSP = Inventory.GetArrayElementAtIndex(lastIndex);

            SerializedProperty previewSP = inventoryItemSP.FindPropertyRelative("Preview");
            SerializedProperty descriptionSP = inventoryItemSP.FindPropertyRelative("Description");
            SerializedProperty costSP = inventoryItemSP.FindPropertyRelative("Cost");

            previewSP.objectReferenceValue = inventoryItem.Preview;
            descriptionSP.stringValue = inventoryItem.Description;
            costSP.intValue = inventoryItem.Cost;

            Inventory.serializedObject.ApplyModifiedProperties();
        }
    }

    /*
     * Links:
     * EditorGUILayout.LabelField: https://docs.unity3d.com/ScriptReference/EditorGUILayout.LabelField.html
     * EditorGUIUtility.labelWidth: https://docs.unity3d.com/ScriptReference/EditorGUIUtility-labelWidth.html
     * 
     * EditorGUILayout.BeginScrollView: https://docs.unity3d.com/ScriptReference/EditorGUILayout.BeginScrollView.html
     * GUILayout.Height: https://docs.unity3d.com/ScriptReference/GUILayout.Height.html
     * 
     * SerializedProperty.arraySize: https://docs.unity3d.com/ScriptReference/SerializedProperty-arraySize.html
     * SerializedProperty.GetArrayElementAtIndex: https://docs.unity3d.com/ScriptReference/SerializedProperty.GetArrayElementAtIndex.html
     * 
     * SerializedProperty.FindPropertyRelative: https://docs.unity3d.com/ScriptReference/SerializedProperty.FindPropertyRelative.html
     * EditorGUILayout.BeginHorizontal: https://docs.unity3d.com/ScriptReference/EditorGUILayout.BeginHorizontal.html
     * 
     * EditorGUILayout.EndHorizontal: https://docs.unity3d.com/ScriptReference/EditorGUILayout.EndHorizontal.html
     * SerializedProperty.objectReferenceValue: https://docs.unity3d.com/ScriptReference/SerializedProperty-objectReferenceValue.html
     * 
     * GUILayout.Width: https://docs.unity3d.com/ScriptReference/GUILayout.Width.html
     * SerializedProperty.InsertArrayElementAtIndex: https://docs.unity3d.com/ScriptReference/SerializedProperty.InsertArrayElementAtIndex.html
     * 
     * SerializedObject.ApplyModifiedProperties: https://docs.unity3d.com/ScriptReference/SerializedObject.ApplyModifiedProperties.html
     * Editor.CreateEditor: https://docs.unity3d.com/ScriptReference/Editor.CreateEditor.html
     * 
     * See also:
     * EditorGUILayout.BeginVertical: https://docs.unity3d.com/ScriptReference/EditorGUILayout.BeginVertical.html
     * EditorGUILayout.EndVertical: https://docs.unity3d.com/ScriptReference/EditorGUILayout.EndVertical.html
     */
}
