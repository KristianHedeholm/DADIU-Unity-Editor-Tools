using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemDatabase))]
public class ItemDatabaseCustomInspector : Editor
{
    private bool _useDefaultInspector = true;

    private SerializedProperty Items;
    private ItemDatabase _target;
    private List<ItemData> _itemDataList;

    private string _seacrhName;
    private string _seacrhTags;
    private WeaponType _seacrhWeaponType = WeaponType.None;
    private const float _minimumPrice = 0.0f;
    private const float _maximimumPrice = 150000.0f;
    private float _minimumRangeValue = _minimumPrice;
    private float _maximumRangeValue = _maximimumPrice;

    private void OnEnable()
    {
        Items = serializedObject.FindProperty("Items");
        _target = target as ItemDatabase;
        ResetToFullList();
    }

    private void ResetToFullList()
    {
        _itemDataList = new List<ItemData>();
        _itemDataList.AddRange(_target.Items);
    }

    public override void OnInspectorGUI()
    {
        _useDefaultInspector = EditorGUILayout.Toggle("Use Default Inspector", _useDefaultInspector);

        if (_useDefaultInspector)
        {
            DrawDefaultInspector();
            return;
        }

        _seacrhName = EditorGUILayout.TextField("Search for Name", _seacrhName);

        GUILayout.Space(5);

        _seacrhTags = EditorGUILayout.TextField("Search for Tags", _seacrhTags);

        GUILayout.Space(5);

        _seacrhWeaponType = (WeaponType)EditorGUILayout.EnumPopup("Search for Weapon Type", _seacrhWeaponType);

        GUILayout.Space(5);

        EditorGUILayout.LabelField("Price Range: ");
        EditorGUILayout.MinMaxSlider(ref _minimumRangeValue, ref _maximumRangeValue, _minimumPrice, _maximimumPrice);

        var minimumValue = Mathf.RoundToInt(_minimumRangeValue);
        EditorGUILayout.LabelField("Minimum Value: " + minimumValue);

        GUILayout.Space(5);

        var maximumValue = Mathf.RoundToInt(_maximumRangeValue);
        EditorGUILayout.LabelField("Maximum Value: " + maximumValue);


        GUILayout.Space(5);


        if (GUILayout.Button("Reset"))
        {
            _seacrhName = string.Empty;
            _seacrhTags = string.Empty;
            _seacrhWeaponType = WeaponType.None;
            _minimumRangeValue = _minimumPrice;
            _maximumRangeValue = _maximimumPrice;

            ResetToFullList();
        }

        GUILayout.Space(15);

        if(GUILayout.Button("Update List based on Search Filter"))
        {
            ResetToFullList();

            _itemDataList = _itemDataList
                .GetItemsBasedOnNameSearch(_seacrhName)
                .GetItemsBasedOnTagsSearch(_seacrhTags)
                .GetItemsBasedOnWeaponTypeSearch(_seacrhWeaponType)
                .GetItemsBasedOnPriceRange(_minimumRangeValue, _maximumRangeValue);
        }

        GUILayout.Space(10);

        if(GUILayout.Button("Save changes"))
        {
            for (int itemIndex = 0; itemIndex < _itemDataList.Count; itemIndex++)
            {
                for (int itemDataIndex = 0; itemDataIndex < _target.Items.Length; itemDataIndex++)
                {
                    if(_target.Items[itemDataIndex].ID == _itemDataList[itemIndex].ID)
                    {
                        _target.Items[itemDataIndex] = _itemDataList[itemIndex];
                    }
                }
            }
        }


        EditorGUILayout.LabelField("Item Database:");


        for (int i = 0; i < _itemDataList.Count; i++)
        {
            var item = _itemDataList[i];
            DrawItem(ref item);
            _itemDataList[i] = item;
        }
    }

    private void DrawItem(ref ItemData item)
    {
        item.Name = EditorGUILayout.TextField("Name: ", item.Name);
        item.Tags = EditorGUILayout.TextField("Tags: ", item.Tags);
        item.Price = EditorGUILayout.IntField("Price: ", item.Price);
        item.WeaponType = (WeaponType)EditorGUILayout.EnumPopup("Weapon Type: ", item.WeaponType);

        EditorGUILayout.LabelField("Stats");

        EditorGUI.indentLevel++;
        
        var stats = item.Stats;
        stats.Attack = EditorGUILayout.IntField("Attack: ", stats.Attack);
        stats.Defence = EditorGUILayout.IntField("Defence: ", stats.Defence);
        stats.Speed = EditorGUILayout.IntField("Speed: ", stats.Speed);
        stats.Magic = EditorGUILayout.IntField("Magic: ", stats.Magic);
        item.Stats = stats;

        EditorGUI.indentLevel--;

        GUILayout.Space(10);

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        GUILayout.Space(10);
    }
}
