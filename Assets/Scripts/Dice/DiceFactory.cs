using System;
using UnityEngine;

namespace VD
{
    [CreateAssetMenu(fileName = "DiceFactory", menuName = "Factory/DiceFactory")]
    public class DiceFactory : ScriptableObject, IDiceConfigProvider
    {
        [SerializeField] private DiceConfig _attackPlayer, _attackEnemy, _health;

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
                    return _attackPlayer;
                default:
                    throw new ArgumentException(nameof(type));

            }
        }

        DiceConfig IDiceConfigProvider.GetConfig(DiceType type)
        {
            return GetConfig(type);
        }
    }
}
