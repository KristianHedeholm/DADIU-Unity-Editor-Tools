namespace Examples.ScriptableObjects.SO3
{
    using UnityEngine;

    public class PlayerSO3 : MonoBehaviour
    {
        [SerializeField]
        private HealthDataScriptableObject healthData;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Attack the enemy!");
                EnemySO3.Instance.AttackEnemy(1);
            }

            if(Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("I took damae!");
                healthData.TakeDamage(1);
            }

            if(Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("Nice Health postion!");
                healthData.GainHealth(1);
            }
        }
    }
}
