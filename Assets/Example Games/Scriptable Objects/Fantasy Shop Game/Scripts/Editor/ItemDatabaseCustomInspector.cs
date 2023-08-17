using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemDatabase))]
public class ItemDatabaseCustomInspector : Editor
{
    private bool _useDefaultInspector = true;

    private SerializedProperty _items;

    private void OnEnable()
    {
        _items = serializedObject.FindProperty("_items");
    }

    public override void OnInspectorGUI()
    {
        _useDefaultInspector = EditorGUILayout.Toggle("Use Default Inspector", _useDefaultInspector);

        if (_useDefaultInspector)
        {
            DrawDefaultInspector();
            return;
        }

        EditorGUILayout.PropertyField(_items);
    }
}
