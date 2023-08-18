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


        if (GUILayout.Button("Reset"))
        {
            _seacrhName = string.Empty;
            _seacrhTags = string.Empty;
            _seacrhWeaponType = WeaponType.None;
        }

        GUILayout.Space(15);



        if(GUILayout.Button("Update List based on Search Filter"))
        {
            ResetToFullList();

            _itemDataList = GetItemsBasedOnNameSearch(_seacrhName, _itemDataList);
            _itemDataList = GetItemsBasedOnTagsSearch(_seacrhTags, _itemDataList);
            _itemDataList = GetItemsBasedOnWeaponTypeSearch(_seacrhWeaponType, _itemDataList);

            foreach (var item in _itemDataList)
            {
                Debug.Log(item.Name);
            }
        }
    }

    private List<ItemData> GetItemsBasedOnNameSearch(string name, List<ItemData> inputValue)
    {
        if(string.IsNullOrEmpty(name))
        {
            return inputValue;
        }

        var newList = new List<ItemData>();
        foreach (var item in inputValue)
        {
            if(item.Name.Contains(name))
            {
                newList.Add(item);
                Debug.Log(item.Name);
            }
        }
        return newList;
    }

    private List<ItemData> GetItemsBasedOnTagsSearch(string tags, List<ItemData> inputValue)
    {
        if (string.IsNullOrEmpty(tags))
        {
            return inputValue;
        }

        var newList = new List<ItemData>();
        foreach (var item in inputValue)
        {
            if (item.Tags.Contains(tags))
            {
                newList.Add(item);
            }
        }
        return newList;
    }

    private List<ItemData> GetItemsBasedOnWeaponTypeSearch(WeaponType weaponType, List<ItemData> inputValue)
    {
        if (weaponType == WeaponType.None)
        {
            return inputValue;
        }

        var newList = new List<ItemData>();
        foreach (var item in inputValue)
        {
            if (item.WeaponType == weaponType)
            {
                newList.Add(item);
            }
        }
        return newList;
    }
}
