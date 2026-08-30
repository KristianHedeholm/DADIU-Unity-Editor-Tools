namespace Examples.ScriptableObjects.SO2
{
    using UnityEngine;


    public class EnemySO2 : MonoBehaviour
    {
        private EnemyData enemyData;

        [SerializeField]
        private EnemyDataScriptableObject enemyDataScriptableObject;

        private void Awake()
        {
            if(enemyDataScriptableObject != null)
            {
				enemyData = enemyDataScriptableObject.EnemyData;
				Debug.Log($"Hi I'm a {enemyData.EnemyType} and I give {enemyData.AttackPower} damge and have {enemyData.Health} in health");
            }
            else
            {
                Debug.Log("I have no Enemy Data!!!");
            }
        }
    }
}
