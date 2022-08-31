namespace Examples.ScriptableObjects.SO3
{
    using UnityEngine;

    public class Enemy : MonoBehaviour
    {
        public static Enemy Instance;

        [SerializeField]
        private HealthDataScriptableObject healthData;

        private void Awake()
        {
            Instance = this;
        }

        public void AttackEnemy(int damage)
        {
            healthData.TakeDamage(damage);
            if(!healthData.IsAlive)
            {
                Debug.Log("Oh No I'm a dead enemy!");
            }
        }
    }
}
