namespace Examples.ScriptableObjects.SO2
{
    using UnityEngine;

    public enum EnemyType
    {
        Goblin,
        Orc,
        Demon,
    }

    public class EnemySO2 : MonoBehaviour
    {
        private EnemyType enemyType;
        private int attackPower;
        private int health;

        [SerializeField]
        private EnemyDataScriptableObject enemyData;

        private void Awake()
        {
            if(enemyData != null)
            {
                enemyType = enemyData.EnemyType;
                attackPower = enemyData.AttackPower;
                health = enemyData.Health;

                Debug.Log($"Hi I'm a {enemyType.ToString()} and I give {attackPower} damge and have {health} in health");
            }
            else
            {
                Debug.Log("I have no Enemy Data!!!");
            }
        }
    }
}
