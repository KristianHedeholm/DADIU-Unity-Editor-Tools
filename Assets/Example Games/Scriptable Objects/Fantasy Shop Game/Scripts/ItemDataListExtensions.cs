using System.Collections.Generic;

public static class ItemDataListExtensions
{
    public static List<ItemData> GetItemsBasedOnNameSearch(this List<ItemData> inputValue, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return inputValue;
        }

        var newList = new List<ItemData>();
        foreach (var item in inputValue)
        {
            if (item.Name.Contains(name))
            {
                newList.Add(item);
            }
        }
        return newList;
    }

    public static List<ItemData> GetItemsBasedOnTagsSearch(this List<ItemData> inputValue, string tags)
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

    public static List<ItemData> GetItemsBasedOnWeaponTypeSearch(this List<ItemData> inputValue, WeaponType weaponType)
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

    public static List<ItemData> GetItemsBasedOnPriceRange(this List<ItemData> inputValue, float minimumValue, float maximumValue)
    {
        var newList = new List<ItemData>();
        foreach (var item in inputValue)
        {
            if (minimumValue <= item.Price && item.Price <= maximumValue)
            {
                newList.Add(item);
            }
        }
        return newList;
    }
}
