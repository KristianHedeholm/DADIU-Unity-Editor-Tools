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
