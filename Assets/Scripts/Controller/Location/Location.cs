using System;
using UnityEngine;

namespace VD
{
    [CreateAssetMenu(fileName = "Location", menuName = "Location/Location")]
    public class Location : ScriptableObject
    {
        [SerializeField] LocationView _locationView;
        [SerializeField] private int _numberofLevels;
        [SerializeField] private LocationType _locationType;
        [SerializeField] private DiceFactory _diceFactory;
        [SerializeField] private RollDiceConfig _rollDiceConfig;
        [SerializeField] private EnemyFactory _enemyFactory;

        public LocationView LocationView => _locationView;
        public int NumberofLevels => _numberofLevels;
        public LocationType LocationType => _locationType;
        public DiceFactory DiceFactory => _diceFactory;
        public RollDiceConfig RollDiceConfig => _rollDiceConfig;
        public EnemyFactory EnemyFactory => _enemyFactory;


    }
}
