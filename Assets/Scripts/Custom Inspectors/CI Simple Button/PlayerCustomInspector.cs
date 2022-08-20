namespace Examples.CustomInspectors.CI1
{
    using UnityEngine;
    using UnityEditor;

    [CustomEditor(typeof(Player))]
    public class PlayerCustomInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GUILayout.Space(5);

            if(GUILayout.Button("Click Me"))
            {
                Debug.Log("Yay you clicked me!");
            }
        }
    }
}
