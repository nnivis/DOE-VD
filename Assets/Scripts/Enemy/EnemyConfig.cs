using UnityEngine;

namespace VD
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Config/EnemyConfig", order = 2)]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private int _health;
        [SerializeField] private int _damage;

        public Enemy Prefab => _prefab;
        public int Health => _health;
        public int Damage => _damage;
    }
}
