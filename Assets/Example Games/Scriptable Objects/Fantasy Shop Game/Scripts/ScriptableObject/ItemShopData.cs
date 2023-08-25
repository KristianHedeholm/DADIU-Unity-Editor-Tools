using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ItemShopData", menuName = "Scriptable Objects/Item Shop Data")]
public class ItemShopData : ScriptableObject
{
    public const int MaximumItemsInShop = 9;
    public string ShopName => _shopName;

    [SerializeField]
    private ItemDatabase ItemDatabase;

    [SerializeField]
    private string _shopName;
    [SerializeField]
    private string Tags;
    [SerializeField]
    private WeaponType WeaponType;
    [SerializeField]
    private int MinimumPrize;
    [SerializeField]
    private int MaximumPrice = ItemDatabase.MaximumPrice;
    [SerializeField]
    private bool _useRandomItems;
    
    public ItemData[] GetShopItems()
    {
        var itemList = new List<ItemData>();
        itemList.AddRange(ItemDatabase.Items);

        itemList = itemList
            .GetItemsBasedOnTagsSearch(Tags)
            .GetItemsBasedOnWeaponTypeSearch(WeaponType)
            .GetItemsBasedOnPriceRange(MinimumPrize, MaximumPrice);

        if (itemList.Count > MaximumItemsInShop)
        {
            while (itemList.Count > MaximumItemsInShop)
            {
                var index = (_useRandomItems) ? Random.Range(0, itemList.Count) : itemList.Count - 1;
                itemList.RemoveAt(index);
            }
        }
        return itemList.ToArray();
    }

    [ContextMenu("Reset Values")]
    void Reset()
    {
        Tags = null;
        WeaponType = WeaponType.None;
        MinimumPrize = 0;
        MaximumPrice = ItemDatabase.MaximumPrice;
    }
}
