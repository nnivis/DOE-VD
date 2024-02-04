using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace VD
{
    [CreateAssetMenu(fileName = "DiceFactory", menuName = "Factory/DiceFactory")]
    public class DiceFactory : ScriptableObject, IDiceConfigProvider
    {
        [SerializeField] private DiceConfig _attackPlayer, _attackEnemy, _health;
        private DiContainer _container;

        public Dice Get(DiceType type)
        {
            DiceConfig config = GetConfig(type);
            Dice instance = Instantiate(config.Prefab);
            instance.Initialize(this, config.Icon, config.Value, config.Type);
            return instance;
        }

        private DiceConfig GetConfig(DiceType type)
        {
            switch (type)
            {
                case DiceType.AttackPlayer:
                    return _attackPlayer;
                case DiceType.AttackEnemy:
                    return _attackEnemy;
                case DiceType.Health:
                    return _health;
                default:
                    throw new ArgumentException(nameof(type));
            }
        }

        public DiceType GetRandomType(DiceType currentType)
        {
            Array values = Enum.GetValues(typeof(DiceType));

            DiceType[] types = (DiceType[])values;
            types = types.Where(type => type != currentType).ToArray();

            if (types.Length > 0)
            {
                DiceType randomType = types[UnityEngine.Random.Range(0, types.Length)];
                return randomType;
            }
            else
            {
                return currentType;
            }
        }

        DiceConfig IDiceConfigProvider.GetConfig(DiceType type)
        {
            return GetConfig(type);
        }
    }
}
