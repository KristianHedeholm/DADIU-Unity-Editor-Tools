namespace Examples.CustomInspectors.CI3
{
    using UnityEngine;

    public class ChestItem : MonoBehaviour
    {
        [SerializeField]
        private Texture2D Preview;

        [SerializeField]
        private string Description;

        [SerializeField]
        private int Cost;
    }
}
