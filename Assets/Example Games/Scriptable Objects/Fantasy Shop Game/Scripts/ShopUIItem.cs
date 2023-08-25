using UnityEngine;
using UnityEngine.UI;

public class ShopUIItem : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Text _priceText;
    [SerializeField]
    private Button _button;

    public void SetShopItem(ItemData itemData)
    {
        _image.sprite = itemData.Sprite;
        _priceText.text = itemData.Price.ToString();
    }

}
