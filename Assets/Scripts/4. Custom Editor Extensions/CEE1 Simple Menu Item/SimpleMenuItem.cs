namespace Examples.CustomEditorExtensions.CEE1
{
    using UnityEngine;
    using UnityEditor;


    public class SimpleMenuItem
    {
        [MenuItem("Tools/My New Menu Item")]
        public static void MyNewMenuItem()
        {
            Debug.Log("Yay you clicked on my");
        }

        [MenuItem("Tools/Print Selected Object", true)]
        public static bool ValidateHaveSelectedObject()
        {
            return Selection.activeObject != null;
        }

        [MenuItem("Tools/Print Selected Object")]
        public static void ShowHaveSelectedObject()
        {
            Debug.Log(Selection.activeObject.name);
        }
    }

    /*
    * Links
    * MenuItem: https://docs.unity3d.com/ScriptReference/MenuItem.html
    * Selection: https://docs.unity3d.com/ScriptReference/Selection.html
    */
}
