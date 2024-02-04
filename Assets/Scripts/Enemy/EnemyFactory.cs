using UnityEngine;
using Zenject;
using System;
using System.IO;

namespace VD
{
    public class EnemyFactory 
    {
        private const string BlueRadasockConfig = "BlueRadasockConfig";
        private const string RedRarasockConfig = "RedRadasockConfig";
        private const string ConfigsPath = "EnemyConfigs";

        private EnemyConfig _blueRadasock, _redRadasock;
        private DiContainer _container;

        public EnemyFactory(DiContainer container)
        {
            _container = container;
            Load();
        }

        public Enemy Get(EnemyType enemyType)
        {
            EnemyConfig config = GetConfig(enemyType);
            Enemy instance = _container.InstantiatePrefabForComponent<Enemy>(config.Prefab);
            instance.Initialize(config.Health, config.Damage);
            return instance;
        }

        private void Load()
        {
            _blueRadasock = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, BlueRadasockConfig));
            _redRadasock = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, RedRarasockConfig));
        }

        private EnemyConfig GetConfig(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.BlueRadasock:
                    return _blueRadasock;
                case EnemyType.RedRarasock:
                    return _redRadasock;
                default:
                    throw new ArgumentException(nameof(enemyType));
            }
        }
    }
}
