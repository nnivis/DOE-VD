using UnityEngine;

namespace VD
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Config/EnemyConfig", order = 2)]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private int _health;

        public Enemy Prefab => _prefab;
        public int MaxHealth => _health;
    }
}
