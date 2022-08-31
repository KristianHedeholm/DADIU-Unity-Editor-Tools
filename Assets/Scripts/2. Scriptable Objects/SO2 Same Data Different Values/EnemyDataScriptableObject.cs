namespace Examples.ScriptableObjects.SO2
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "Enemy Data Scriptable Object", menuName = "Scriptable Objects/Enemy Data")]
    public class EnemyDataScriptableObject : ScriptableObject
    {
        public EnemyType EnemyType;
        public int AttackPower;
        public int Health;
    }
}
