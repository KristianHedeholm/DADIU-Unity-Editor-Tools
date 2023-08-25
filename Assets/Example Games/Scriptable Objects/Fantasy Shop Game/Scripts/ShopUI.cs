using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public static ShopUI Instance;

    [SerializeField]
    private GameObject _content;

    [SerializeField]
    private Button _exitButton;

    [SerializeField]
    private Text _shopName;

    [SerializeField]
    private ShopUIItem[] _shopUIItems;

    private void Awake()
    {
        Instance = this;
        HideShop();

        _exitButton.onClick.AddListener(HideShop);
    }

    private void OnDestroy()
    {
        _exitButton.onClick.RemoveAllListeners();
    }

    public void ShowUIShop(ItemData[] itemDatas)
    {
        for (int shopUIItemIndex = 0; shopUIItemIndex < _shopUIItems.Length; shopUIItemIndex++)
        {
            if(shopUIItemIndex < itemDatas.Length)
            {
                _shopUIItems[shopUIItemIndex].SetShopItem(itemDatas[shopUIItemIndex]);
                _shopUIItems[shopUIItemIndex].gameObject.SetActive(true);
            }
            else
            {
                _shopUIItems[shopUIItemIndex].gameObject.SetActive(false);
            }
        }

        _content.SetActive(true);
    }

    public void SetShopName(string name)
    {
        _shopName.text = name;
    }

    public void HideShop()
    {
        _content.SetActive(false);
    }
}
