using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemDatabase))]
public class ItemDatabaseCustomInspector : Editor
{
    private bool _useDefaultInspector = true;

    private SerializedProperty Items;
    private ItemDatabase _target;

    private void OnEnable()
    {
        Items = serializedObject.FindProperty("Items");
        _target = target as ItemDatabase;
    }

    public override void OnInspectorGUI()
    {
        _useDefaultInspector = EditorGUILayout.Toggle("Use Default Inspector", _useDefaultInspector);

        if (_useDefaultInspector)
        {
            DrawDefaultInspector();
            return;
        }

        EditorGUILayout.PropertyField(Items);
    }
}
