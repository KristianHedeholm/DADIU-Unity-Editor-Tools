namespace Examples.CustomInspectors.CI3
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

    public class PlayerCI3 : MonoBehaviour
    {
        public InventoryItem[] Inventory;
    }
}
