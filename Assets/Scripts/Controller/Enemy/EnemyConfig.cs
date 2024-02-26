using System;
using UnityEngine;

namespace VD
{
    [Serializable]
    public class EnemyConfig
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private int _health;

        public Enemy Prefab => _prefab;
        public int MaxHealth => _health;
    }
}
