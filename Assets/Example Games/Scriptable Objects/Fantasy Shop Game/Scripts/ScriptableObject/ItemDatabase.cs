using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Scriptable Objects/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public const int MaximumPrice = 150000;

    public ItemData[] Items;

    // This approach is not 100% bullet proof. For example this don't allow having commas in the names of the items.
    // It would be nice to find an elegant solution that can handle situations like that in a smart way.
    // A possible sultion: Create a list and if the dataValue don't contain a ' " ' we just add it right away to the list.
    // If the dataValue contsins a ' " ' in the first spot, we keep adding entries to we find a corrasponding ' " ' character.
    // Afterwards we can remove the ' " * from the string. This should now only contain the values we actually need.
    [ContextMenu("Load CSV File")]
    private void LoadDataBaseFromCSVFile()
    {
        Items = new ItemData[0];

        var guids = AssetDatabase.FindAssets($"t:{typeof(TextAsset).Name}, items, ", new string[] { "Assets/" });
        var path = AssetDatabase.GUIDToAssetPath(guids[0]);
        path = path.Replace("Assets", "");
        var fullPath = Path.GetFullPath(Application.dataPath + path);

        var listOfItems = new List<ItemData>();

        using (StreamReader reader = new StreamReader(fullPath))
        {
            while (true)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                var values = line.Split(',');

                if (values[0].Contains("Name"))
                {
                    continue;
                }

                ItemData itemData = new ItemData();
                itemData.Name = values[0];
                itemData.ID = Convert.ToInt32(values[1]);

                var addedIndex = 2;
                var tags = values[addedIndex];
                if (!string.IsNullOrEmpty(tags))
                {
                    var endOfTagString = false;
                    while (!endOfTagString)
                    {
                        addedIndex++;
                        tags += values[addedIndex];
                        if (tags.EndsWith('"'))
                        {
                            endOfTagString = true;
                            break;
                        }
                    }
                }
                itemData.Tags = tags;
                itemData.Price = Convert.ToInt32(values[addedIndex + 1]);
                itemData.WeaponType = Enum.Parse<WeaponType>(values[addedIndex + 2]);


                Stats stats = new Stats()
                {
                    Attack = Convert.ToInt32(values[addedIndex + 3]),
                    Defence = Convert.ToInt32(values[addedIndex + 4]),
                    Speed = Convert.ToInt32(values[addedIndex + 5]),
                    Magic = Convert.ToInt32(values[addedIndex + 6]),
                };

                var spriteName = values[addedIndex + 7];

                var spriteGuids = AssetDatabase.FindAssets($"t:{typeof(Sprite).Name}, {spriteName}, ", new string[] { "Assets/Example Games/Scriptable Objects/Fantasy Shop Game/Graphics/Classic 100" });
                var spritePath = AssetDatabase.GUIDToAssetPath(spriteGuids[0]);
                var sprite = AssetDatabase.LoadAssetAtPath(spritePath, typeof(Sprite)) as Sprite;
                itemData.Sprite = sprite;

                Reward reward = new Reward();
                reward.Coins = Convert.ToInt32(values[addedIndex + 8]);

                var numberOfValues = values.Length;
                var currentIndex = addedIndex + 9;
                for (int index = currentIndex; index < numberOfValues; index++)
                {
                    reward.IDsForItem += values[index];
                }

                itemData.Stats = stats;
                itemData.Reward = reward;
                listOfItems.Add(itemData);
            }
        }
        Items = listOfItems.ToArray();
    }
}

[Serializable]
public struct ItemData
{
    public string Name;
    public int ID;
    public string Tags;
    public int Price;
    public WeaponType WeaponType;
    public Stats Stats;
    public Sprite Sprite;
    public Reward Reward;
}

public enum WeaponType
{
    None,
    Sword,
    Spear,
    Axe,
    Throwable,
}

[Serializable]
public struct Stats
{
    public int Attack;
    public int Defence;
    public int Speed;
    public int Magic;
}

[Serializable]
public struct Reward
{
    public int Coins;
    public string IDsForItem;
}
