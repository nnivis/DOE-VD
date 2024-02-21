using System;
using UnityEngine;

namespace VD
{
    [Serializable]
    public class LocationConfig
    {
        [SerializeField] private Map _map;
        [SerializeField] private int _numberofLevels;
        [SerializeField] private LocationType _locationType;
        [SerializeField] private DiceFactory _diceFactory;
        [SerializeField] private RollDiceConfig _rollDiceConfig;

        public Map Map => _map;
        public int NumberofLevels => _numberofLevels;
        public LocationType LocationType => _locationType;
        public DiceFactory DiceFactory => _diceFactory;
        public RollDiceConfig RollDiceConfig => _rollDiceConfig;

        
    }
}
