using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public static ShopUI Instance;

    [SerializeField]
    private Text _shopName;

    [SerializeField]
    private ShopUIItem[] _shopUIItems;

    private void Awake()
    {
        Instance = this;
        
    }
}
