namespace Examples.ScriptableObjects.SO2
{
	using System;
	using UnityEngine;

	public enum EnemyType
	{
		Goblin,
		Orc,
		Demon,
	}

	[Serializable]
    public struct EnemyData
    {
		public EnemyType EnemyType;
		public int AttackPower;
		public int Health;
	}

    [CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable Objects/Enemy Data")]
    public class EnemyDataScriptableObject : ScriptableObject
    {
        public EnemyData EnemyData;
    }
}
