namespace Examples.ScriptableObjects.SO1
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "My Simple Scriptable Object", menuName = "Scriptable Objects/My Simple Scriptable Object")]
    public class SimpleScriptableObject : ScriptableObject
    {
        [SerializeField]
        private int intValue;
        [SerializeField]
        private float floatValue;
        [SerializeField]
        private bool boolValue;
    }

    /*
     * Links:
     * CreateAssetMenu: https://docs.unity3d.com/ScriptReference/CreateAssetMenuAttribute.html
     * ScriptableObject: https://docs.unity3d.com/ScriptReference/ScriptableObject.html
     */
}
