namespace Examples.ScriptableObjects.SO3
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "Health Data", menuName = "Scriptable Objects/Health Data")]
    public class HealthDataScriptableObject : ScriptableObject
    {
        public bool IsAlive
        {
            get
            {
                return currentHealth > 0;
            }
        }

        [SerializeField]
        private int startHealth;

        [SerializeField]
        private int currentHealth;

        [SerializeField]
        private int maxHealth;

        public void TakeDamage(int damgeValue)
        {
            currentHealth -= damgeValue;
        }

        public void GainHealth(int gainValue)
        {
            currentHealth += gainValue;
            if(currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

        public void ResetToStartHealth()
        {
            currentHealth = startHealth;
        }
    }
}
