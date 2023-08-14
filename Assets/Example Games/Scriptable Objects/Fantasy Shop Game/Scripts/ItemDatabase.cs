using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Scriptable Objects/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public ItemData[] _items;
}

[Serializable]
public struct ItemData
{
    public string Name;
    public int ID;
    public string Tags;
    public int Price;
    public Stats Stats;
    public Reward Reward;
    public Sprite Sprite;
}

[Serializable]
public struct Stats
{
    public int Attack;
    public int Defence;
    public int Speed;
}

[Serializable]
public struct Reward
{
    public int Coins;
    public int IDForItem;
}
