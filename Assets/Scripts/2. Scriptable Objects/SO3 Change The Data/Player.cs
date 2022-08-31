namespace Examples.ScriptableObjects.SO3
{
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        [SerializeField]
        private HealthDataScriptableObject healthData;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Attack the enemy!");
                Enemy.Instance.AttackEnemy(1);
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
