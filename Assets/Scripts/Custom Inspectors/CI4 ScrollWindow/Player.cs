namespace Examples.CustomInspectors.CI4
{
    using UnityEngine;
    using System;

    [Serializable]
    public struct InventoryItem
    {
        public Texture2D Preview;
        public string Description;
        public int Cost;
    }

    public class Player : MonoBehaviour
    {
        public InventoryItem[] Inventory;
    }
}
