using UnityEngine;

public class ItemShop : MonoBehaviour
{
    [SerializeField]
    private ItemShopData _itemShopData;

    [SerializeField]
    private ItemData[] _cachedItems;

    private void Awake()
    {
        if(_itemShopData == null)
        {
            Debug.LogError("Error: No ItemShop Data assigned");
        }
        _cachedItems = _itemShopData.GetShopItems();

    }


    public void ShowShop()
    {
        ShopUI.Instance.SetShopName(_itemShopData.ShopName);
        ShopUI.Instance.ShowUIShop(_cachedItems);
    }
}
